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
    public partial class FrmCategoriaEdit : Form
    {
        private readonly ICategoriaServicio _servicio;
        private readonly int _id;
        private readonly Categoria _categoria;

        public FrmCategoriaEdit(ICategoriaServicio servicio, int id)
        {
            InitializeComponent();
            _servicio = servicio;
            _id = id;
            _categoria = id > 0 ? _servicio.ObtenerPorId(id) : new Categoria();

            Load += FrmCategoriaEdit_Load;
            btnAgregarFoto.Click += BtnAgregarFoto_Click;
            btnQuitarFoto.Click += (s, e) => { if (lstFotos.SelectedIndex >= 0) lstFotos.Items.RemoveAt(lstFotos.SelectedIndex); };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void FrmCategoriaEdit_Load(object sender, EventArgs e)
        {
            Text = _id > 0 ? "Editar Categoria" : "Nueva Categoria";
            if (_id > 0)
            {
                txtNombre.Text = _categoria.Nombre;
                txtDescripcion.Text = _categoria.Descripcion;
                foreach (var foto in _categoria.RutasFotos) lstFotos.Items.Add(foto);
            }
        }

        private void BtnAgregarFoto_Click(object sender, EventArgs e)
        {
            epCategoria.Clear();
            if (lstFotos.Items.Count >= 5)
            {
                epCategoria.SetError(lstFotos, "Maximo 5 fotos.");
                return;
            }

            using (var ofd = new OpenFileDialog { Filter = "Imagenes|*.jpg;*.jpeg;*.png" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (new FileInfo(ofd.FileName).Length > 2 * 1024 * 1024)
                    {
                        epCategoria.SetError(lstFotos, "La imagen supera los 2 MB.");
                        return;
                    }
                    lstFotos.Items.Add(ofd.FileName);
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            epCategoria.Clear();
            _categoria.Nombre = txtNombre.Text.Trim();
            _categoria.Descripcion = txtDescripcion.Text.Trim();
            _categoria.RutasFotos = lstFotos.Items.Cast<string>().ToList();

            var res = _servicio.Guardar(_categoria);
            if (res.Exito)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (res.Mensaje.Contains("nombre")) epCategoria.SetError(txtNombre, res.Mensaje);
                else if (res.Mensaje.Contains("descripción")) epCategoria.SetError(txtDescripcion, res.Mensaje);
                else if (res.Mensaje.Contains("foto")) epCategoria.SetError(lstFotos, res.Mensaje);
                else MessageBox.Show(res.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
