using System;
using System.Windows.Forms;
using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fabrica = new FabricaServicios();
            var categoriaServicio = fabrica.CrearCategoriaServicio();
            var suplidorServicio = fabrica.CrearSuplidorServicio();
            var productoServicio = fabrica.CrearProductoServicio();

            Application.Run(new FormPrincipal(categoriaServicio, suplidorServicio, productoServicio));
        }
    }
}