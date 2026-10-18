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
    public partial class FrmSuplidorEdit : Form
    {
        private readonly ISuplidorServicio _servicio;
        private readonly int _id;
        private readonly Suplidor _suplidor;

        public FrmSuplidorEdit(ISuplidorServicio servicio, int id)
        {
            InitializeComponent();
            _servicio = servicio;
            _id = id;
            _suplidor = id > 0 ? _servicio.ObtenerPorId(id) : new Suplidor();

            Load += FrmSuplidorEdit_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void FrmSuplidorEdit_Load(object sender, EventArgs e)
        {
            Text = _id > 0 ? "Editar Suplidor" : "Nuevo Suplidor";
            if (_id > 0)
            {
                txtNombreEmpresa.Text = _suplidor.NombreEmpresa;
                txtNombreContacto.Text = _suplidor.NombreContacto;
                txtTelefono.Text = _suplidor.Telefono;
                txtEmail.Text = _suplidor.Email;
                txtSitioWeb.Text = _suplidor.SitioWeb;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            epSuplidor.Clear();
            _suplidor.NombreEmpresa = txtNombreEmpresa.Text.Trim();
            _suplidor.NombreContacto = txtNombreContacto.Text.Trim();
            _suplidor.Telefono = txtTelefono.Text.Trim();
            _suplidor.Email = txtEmail.Text.Trim();
            _suplidor.SitioWeb = string.IsNullOrWhiteSpace(txtSitioWeb.Text) ? null : txtSitioWeb.Text.Trim();

            var res = _servicio.Guardar(_suplidor);
            if (res.Exito)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (res.Mensaje.Contains("empresa")) epSuplidor.SetError(txtNombreEmpresa, res.Mensaje);
                else if (res.Mensaje.Contains("contacto")) epSuplidor.SetError(txtNombreContacto, res.Mensaje);
                else if (res.Mensaje.Contains("teléfono")) epSuplidor.SetError(txtTelefono, res.Mensaje);
                else if (res.Mensaje.Contains("correo")) epSuplidor.SetError(txtEmail, res.Mensaje);
                else if (res.Mensaje.Contains("web")) epSuplidor.SetError(txtSitioWeb, res.Mensaje);
                else MessageBox.Show(res.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
