using SistemaInventario.LogicaNegocio;

namespace SistemaInventario
{
    public partial class FormPrincipal : Form
    {
        private readonly ICategoriaServicio _catServicio;
        private readonly ISuplidorServicio _supServicio;
        private readonly IProductoServicio _prodServicio;

        public FormPrincipal(ICategoriaServicio catServicio, ISuplidorServicio supServicio, IProductoServicio prodServicio)
        {
            InitializeComponent();
            _catServicio = catServicio;
            _supServicio = supServicio;
            _prodServicio = prodServicio;

            MenuCategorias.Click += (s, e) => new FrmCategoriasList(_catServicio).ShowDialog();
            menuSuplidores.Click += (s, e) => new FrmSuplidoresList(_supServicio).ShowDialog();
            menuProductos.Click += (s, e) => new FrmProductosList(_prodServicio, _catServicio, _supServicio).ShowDialog();
            menuPapelera.Click += (s, e) => new FrmPapelera(_catServicio, _supServicio, _prodServicio).ShowDialog();
            menuReportes.Click += (s, e) => new FrmReportes(_prodServicio).ShowDialog();
            MenuSalir.Click += (s, e) => Close();
        }
    }
}
    
