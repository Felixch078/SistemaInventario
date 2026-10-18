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
    public partial class FrmSuplidoresList : Form
    {
        private readonly ISuplidorServicio _servicio;

        public FrmSuplidoresList(ISuplidorServicio servicio)
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
            dgvSuplidores.DataSource = new BindingList<Suplidor>(_servicio.ListarActivos());
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            if (dgvSuplidores.Columns["Activo"] != null) dgvSuplidores.Columns["Activo"].Visible = false;
            if (dgvSuplidores.Columns["FechaCreacion"] != null) dgvSuplidores.Columns["FechaCreacion"].Visible = false;
            if (dgvSuplidores.Columns["FechaModificacion"] != null) dgvSuplidores.Columns["FechaModificacion"].Visible = false;
        }

        private void Filtrar()
        {
            var texto = txtBuscar.Text.Trim().ToLower();
            var lista = _servicio.ListarActivos()
                .Where(s => string.IsNullOrEmpty(texto)
                         || s.NombreEmpresa.ToLower().Contains(texto)
                         || s.NombreContacto.ToLower().Contains(texto))
                .ToList();
            dgvSuplidores.DataSource = new BindingList<Suplidor>(lista);
            OcultarColumnas();
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvSuplidores.CurrentRow?.DataBoundItem is Suplidor sup) return sup.Id;
            MessageBox.Show("Seleccione un suplidor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 0;
        }

        private void AbrirEditor(int id)
        {
            using (var frm = new FrmSuplidorEdit(_servicio, id))
            {
                if (frm.ShowDialog() == DialogResult.OK) CargarGrid();
            }
        }

        private void Eliminar()
        {
            int id = ObtenerIdSeleccionado();
            if (id == 0) return;

            if (MessageBox.Show("¿Eliminar este suplidor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var res = _servicio.Eliminar(id);
                if (res.Exito) CargarGrid();
                else MessageBox.Show(res.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
