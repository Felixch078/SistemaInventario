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
    public partial class FrmReportes : Form
    {
        private readonly IProductoServicio _servicio;

        public FrmReportes(IProductoServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;

            Load += (s, e) =>
            {
                cmbReporte.Items.AddRange(new object[] {
                    "1. Productos agrupados por categoria",
                    "2. Top 5 suplidores con mas productos",
                    "3. Productos por categoria y rango de precio (Ejemplo: > 1000)",
                    "4. Búsqueda de productos por nombre",
                    "5. Promedio de precio por categoría"
                });
                cmbReporte.SelectedIndex = 0;
            };

            btnEjecutar.Click += BtnEjecutar_Click;
            btnCerrar.Click += (s, e) => Close();
        }

        private void BtnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbReporte.SelectedIndex)
                {
                    case 0: dgvReportes.DataSource = _servicio.ProductosPorCategoria(); break;
                    case 1: dgvReportes.DataSource = _servicio.Top5Suplidores(); break;
                    case 2: dgvReportes.DataSource = _servicio.ProductosPorCategoriaYRango(0, 1000m, 999999m); break;
                    case 3: dgvReportes.DataSource = _servicio.Buscar(""); break;
                    case 4: dgvReportes.DataSource = _servicio.PromedioPorCategoria(); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
