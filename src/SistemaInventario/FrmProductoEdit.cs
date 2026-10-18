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
    public partial class FrmProductoEdit : Form
    {
        private readonly IProductoServicio _servicio;
        private readonly int _id;
        private readonly Producto _producto;

        public FrmProductoEdit(IProductoServicio servicio, ICategoriaServicio catServicio, ISuplidorServicio supServicio, int id)
        {
            InitializeComponent();
            _servicio = servicio;
            _id = id;
            _producto = id > 0 ? _servicio.ObtenerPorId(id) : new Producto();

            Load += (s, e) =>
            {
                cmbCategoria.DataSource = catServicio.ListarActivos();
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "Id";

                cmbSuplidor.DataSource = supServicio.ListarActivos();
                cmbSuplidor.DisplayMember = "NombreEmpresa";
                cmbSuplidor.ValueMember = "Id";

                Text = _id > 0 ? "Editar Producto" : "Nuevo Producto";
                if (_id > 0)
                {
                    txtNombre.Text = _producto.Nombre;
                    nudPrecio.Value = _producto.Precio;
                    cmbCategoria.SelectedValue = _producto.CategoriaId;
                    cmbSuplidor.SelectedValue = _producto.SuplidorId;
                }
            };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            epProducto.Clear();
            _producto.Nombre = txtNombre.Text.Trim();
            _producto.Precio = nudPrecio.Value;
            _producto.CategoriaId = (int)(cmbCategoria.SelectedValue ?? 0);
            _producto.SuplidorId = (int)(cmbSuplidor.SelectedValue ?? 0);

            var res = _servicio.Guardar(_producto);
            if (res.Exito)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (res.Mensaje.Contains("nombre")) epProducto.SetError(txtNombre, res.Mensaje);
                else if (res.Mensaje.Contains("precio")) epProducto.SetError(nudPrecio, res.Mensaje);
                else if (res.Mensaje.Contains("categoría")) epProducto.SetError(cmbCategoria, res.Mensaje);
                else if (res.Mensaje.Contains("suplidor")) epProducto.SetError(cmbSuplidor, res.Mensaje);
                else MessageBox.Show(res.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
