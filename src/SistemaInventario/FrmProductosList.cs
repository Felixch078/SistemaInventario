using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class FrmProductosList : Form
    {
        private readonly IProductoServicio _servicio;
        private readonly ICategoriaServicio _catServicio;
        private readonly ISuplidorServicio _supServicio;

        public FrmProductosList(IProductoServicio servicio, ICategoriaServicio catServicio, ISuplidorServicio supServicio)
        {
            InitializeComponent();
            _servicio = servicio;
            _catServicio = catServicio;
            _supServicio = supServicio;

            Load += FrmProductosList_Load;

            // Eventos de filtrado
            txtBuscar.TextChanged += (s, e) => Filtrar();
            cmbCategoria.SelectedIndexChanged += (s, e) => Filtrar();
            cmbSuplidor.SelectedIndexChanged += (s, e) => Filtrar();
            nudPrecioDesde.ValueChanged += (s, e) => Filtrar();
            nudPrecioHasta.ValueChanged += (s, e) => Filtrar();

            // Eventos de botones
            btnNuevo.Click += (s, e) => AbrirEditor(0);
            btnEditar.Click += (s, e) => AbrirEditor(ObtenerIdSeleccionado());
            btnEliminar.Click += (s, e) => Eliminar();
            btnCerrar.Click += (s, e) => Close();
        }

        private void FrmProductosList_Load(object sender, EventArgs e)
        {
            // CORREGIDO: Primero DisplayMember, luego ValueMember y AL FINAL DataSource
            var cats = _catServicio.ListarActivos();
            cats.Insert(0, new Categoria { Id = 0, Nombre = "(Todas)" });

            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.DataSource = cats;

            // CORREGIDO: Mismo orden para Suplidores
            var sups = _supServicio.ListarActivos();
            sups.Insert(0, new Suplidor { Id = 0, NombreEmpresa = "(Todos)" });

            cmbSuplidor.DisplayMember = "NombreEmpresa";
            cmbSuplidor.ValueMember = "Id";
            cmbSuplidor.DataSource = sups;

            CargarGrid();
        }

        private void CargarGrid()
        {
            dgvProductos.DataSource = new BindingList<Producto>(_servicio.ListarActivos());
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            if (dgvProductos.Columns["Activo"] != null) dgvProductos.Columns["Activo"].Visible = false;
            if (dgvProductos.Columns["FechaCreacion"] != null) dgvProductos.Columns["FechaCreacion"].Visible = false;
            if (dgvProductos.Columns["FechaModificacion"] != null) dgvProductos.Columns["FechaModificacion"].Visible = false;
        }

        private void Filtrar()
        {
            // CORREGIDO: Validación segura para evitar el error de conversión
            if (!(cmbCategoria.SelectedValue is int catId) || !(cmbSuplidor.SelectedValue is int supId))
                return;

            var texto = txtBuscar.Text.Trim().ToLower();
            decimal min = nudPrecioDesde.Value;
            decimal max = nudPrecioHasta.Value;

            var lista = _servicio.ListarActivos()
                .Where(p => string.IsNullOrEmpty(texto) || p.Nombre.ToLower().Contains(texto))
                .Where(p => catId == 0 || p.CategoriaId == catId)
                .Where(p => supId == 0 || p.SuplidorId == supId)
                .Where(p => p.Precio >= min && p.Precio <= max)
                .ToList();

            dgvProductos.DataSource = new BindingList<Producto>(lista);
            OcultarColumnas();
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto prod) return prod.Id;
            MessageBox.Show("Seleccione un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 0;
        }

        private void AbrirEditor(int id)
        {
            using (var frm = new FrmProductoEdit(_servicio, _catServicio, _supServicio, id))
            {
                if (frm.ShowDialog() == DialogResult.OK) CargarGrid();
            }
        }

        private void Eliminar()
        {
            int id = ObtenerIdSeleccionado();
            if (id == 0) return;

            if (MessageBox.Show("¿Eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var res = _servicio.Eliminar(id);
                if (res.Exito) CargarGrid();
                else MessageBox.Show(res.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
