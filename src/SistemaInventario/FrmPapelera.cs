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
    public partial class FrmPapelera : Form
    {
        private readonly ICategoriaServicio _catServicio;
        private readonly ISuplidorServicio _supServicio;
        private readonly IProductoServicio _prodServicio;

        public FrmPapelera(ICategoriaServicio catServicio, ISuplidorServicio supServicio, IProductoServicio prodServicio)
        {
            InitializeComponent();
            _catServicio = catServicio;
            _supServicio = supServicio;
            _prodServicio = prodServicio;

            Load += (s, e) =>
            {
                cmbEntidad.Items.AddRange(new object[] { "Categorias", "Suplidores", "Productos" });
                cmbEntidad.SelectedIndex = 0;
            };

            cmbEntidad.SelectedIndexChanged += (s, e) => CargarGrid();
            btnRestaurar.Click += BtnRestaurar_Click;
            btnCerrar.Click += (s, e) => Close();
        }

        private void CargarGrid()
        {
            switch (cmbEntidad.SelectedIndex)
            {
                case 0: dgvPapelera.DataSource = _catServicio.Listar().Where(c => !c.Activo).ToList(); break;
                case 1: dgvPapelera.DataSource = _supServicio.Listar().Where(s => !s.Activo).ToList(); break;
                case 2: dgvPapelera.DataSource = _prodServicio.Listar().Where(p => !p.Activo).ToList(); break;
            }
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            if (dgvPapelera.Columns["Activo"] != null) dgvPapelera.Columns["Activo"].Visible = false;
            if (dgvPapelera.Columns["RutasFotos"] != null) dgvPapelera.Columns["RutasFotos"].Visible = false;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            if (dgvPapelera.CurrentRow == null) return;

            ResultadoOperacion<object> res = null; 
            string mensaje = "";
            bool exito = false;

            if (cmbEntidad.SelectedIndex == 0 && dgvPapelera.CurrentRow.DataBoundItem is Categoria cat)
            {
                var r = _catServicio.Restaurar(cat.Id);
                exito = r.Exito; mensaje = r.Mensaje;
            }
            else if (cmbEntidad.SelectedIndex == 1 && dgvPapelera.CurrentRow.DataBoundItem is Suplidor sup)
            {
                var r = _supServicio.Restaurar(sup.Id);
                exito = r.Exito; mensaje = r.Mensaje;
            }
            else if (cmbEntidad.SelectedIndex == 2 && dgvPapelera.CurrentRow.DataBoundItem is Producto prod)
            {
                var r = _prodServicio.Restaurar(prod.Id);
                exito = r.Exito; mensaje = r.Mensaje;
            }

            if (exito) CargarGrid();
            else MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
