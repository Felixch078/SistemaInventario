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
    public partial class FrmCategoriasList : Form
    {
        private readonly ICategoriaServicio _servicio;

        public FrmCategoriasList(ICategoriaServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;

            Load += (s, e) => CargarGrid();
            txtBuscar.TextChanged += (s, e) => Filtrar();
            btnNuevo.Click += (s, e) => AbrirEditor(0);
            btnEditar.Click += (s, e) => AbrirEditor(ObtenerIdSeleccionado());
            btnEliminar.Click += (s, e) => Eliminar();
            btnCerrar.Click += (s, e) => Close();
        }

        private void CargarGrid()
        {
            dgvCategorias.DataSource = new BindingList<Categoria>(_servicio.ListarActivos());
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            if (dgvCategorias.Columns["Activo"] != null) dgvCategorias.Columns["Activo"].Visible = false;
            if (dgvCategorias.Columns["RutasFotos"] != null) dgvCategorias.Columns["RutasFotos"].Visible = false;
            if (dgvCategorias.Columns["FechaCreacion"] != null) dgvCategorias.Columns["FechaCreacion"].Visible = false;
            if (dgvCategorias.Columns["FechaModificacion"] != null) dgvCategorias.Columns["FechaModificacion"].Visible = false;
        }

        private void Filtrar()
        {
            var texto = txtBuscar.Text.Trim().ToLower();
            var lista = _servicio.ListarActivos()
                .Where(c => string.IsNullOrEmpty(texto) || c.Nombre.ToLower().Contains(texto))
                .ToList();
            dgvCategorias.DataSource = new BindingList<Categoria>(lista);
            OcultarColumnas();
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvCategorias.CurrentRow?.DataBoundItem is Categoria cat) return cat.Id;
            MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 0;
        }

        private void AbrirEditor(int id)
        {
            using (var frm = new FrmCategoriaEdit(_servicio, id))
            {
                if (frm.ShowDialog() == DialogResult.OK) CargarGrid();
            }
        }

        private void Eliminar()
        {
            int id = ObtenerIdSeleccionado();
            if (id == 0) return;

            if (MessageBox.Show("¿Esta seguro de eliminar esta categoria?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var res = _servicio.Eliminar(id);
                if (res.Exito) CargarGrid();
                else MessageBox.Show(res.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
