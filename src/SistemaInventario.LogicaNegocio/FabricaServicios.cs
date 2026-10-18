using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    /// <summary>arma las dependencias entre repositorios y servicios
    /// La capa Presentación llama a esta clase para obtener servicios sin conocer AccesoDatos</summary>
    public class FabricaServicios
    {
        private readonly IRepositorio<Categoria> _categoriaRepo;
        private readonly IRepositorio<Suplidor> _suplidorRepo;
        private readonly IRepositorio<Producto> _productoRepo;

        /// <summary>Crea los repositorios que serán compartidos por los servicios</summary>
        public FabricaServicios()
        {
            _categoriaRepo = new CategoriaRepositorio();
            _suplidorRepo = new SuplidorRepositorio();
            _productoRepo = new ProductoRepositorio();
        }

        public ICategoriaServicio CrearCategoriaServicio()
            => new CategoriaServicio(_categoriaRepo, _productoRepo);

       public ISuplidorServicio CrearSuplidorServicio()
            => new SuplidorServicio(_suplidorRepo, _productoRepo);

        public IProductoServicio CrearProductoServicio()
            => new ProductoServicio(_productoRepo, _categoriaRepo, _suplidorRepo);
    }
}
