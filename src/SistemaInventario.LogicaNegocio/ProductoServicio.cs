using Microsoft.Data.SqlClient;
using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IRepositorio<Producto> _productoRepo;
        private readonly IRepositorio<Categoria> _categoriaRepo;
        private readonly IRepositorio<Suplidor> _suplidorRepo;

        /// <summary>
        /// Se crea una instancia del servicio inyectando sus repositorios
        /// </summary>
        public ProductoServicio(IRepositorio<Producto> productoRepo,
                                IRepositorio<Categoria> categoriaRepo,
                                IRepositorio<Suplidor> suplidorRepo)
        {
            _productoRepo = productoRepo ?? throw new ArgumentNullException(nameof(productoRepo));
            _categoriaRepo = categoriaRepo ?? throw new ArgumentNullException(nameof(categoriaRepo));
            _suplidorRepo = suplidorRepo ?? throw new ArgumentNullException(nameof(suplidorRepo));
        }

        /// <summary>Devuelve todos los productos</summary>
        public List<Producto> Listar()
        {
            try { return _productoRepo.ObtenerTodos(); }
            catch (SqlException ex) { Logger.Log(ex); return new List<Producto>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<Producto>(); }
        }

        /// <summary>Devuelve solo los productos activos.</summary>
        public List<Producto> ListarActivos()
        {
            try { return _productoRepo.ObtenerActivos(); }
            catch (SqlException ex) { Logger.Log(ex); return new List<Producto>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<Producto>(); }
        }

        /// <summary>Obtiene un producto por Id.</summary>
        public Producto ObtenerPorId(int id)
        {
            try { return _productoRepo.ObtenerPorId(id); }
            catch (SqlException ex) { Logger.Log(ex); return null; }
            catch (Exception ex) { Logger.Log(ex); return null; }
        }

        /// <summary>Valida y guarda un producto.</summary>
        public ResultadoOperacion<Producto> Guardar(Producto producto)
        {
            if (producto == null)
                return ResultadoOperacion<Producto>.Error("El producto no puede ser nulo.");

            var nombre = (producto.Nombre ?? "").Trim();
            if (nombre.Length == 0)
                return ResultadoOperacion<Producto>.Error("El nombre del producto es obligatorio.");
            if (nombre.Length > 150)
                return ResultadoOperacion<Producto>.Error("El nombre no puede superar 150 caracteres.");

            if (producto.Precio <= 0)
                return ResultadoOperacion<Producto>.Error("El precio debe ser mayor a 0.");
            if (decimal.Round(producto.Precio, 2) != producto.Precio)
                return ResultadoOperacion<Producto>.Error("El precio debe tener máximo 2 decimales.");

            try
            {
                var cat = _categoriaRepo.ObtenerPorId(producto.CategoriaId);
                if (cat == null || !cat.Activo)
                    return ResultadoOperacion<Producto>.Error(
                        "La categoria seleccionada no existe o esta inactiva.");

                var sup = _suplidorRepo.ObtenerPorId(producto.SuplidorId);
                if (sup == null || !sup.Activo)
                    return ResultadoOperacion<Producto>.Error(
                        "El suplidor seleccionado no existe o esta inactivo.");

                producto.Nombre = nombre;

                if (producto.Id == 0)
                {
                    producto.Activo = true;
                    producto.FechaCreacion = DateTime.Now;
                    producto.FechaModificacion = DateTime.Now;
                    _productoRepo.Insertar(producto);
                }
                else
                {
                    producto.FechaModificacion = DateTime.Now;
                    _productoRepo.Actualizar(producto);
                }

                return ResultadoOperacion<Producto>.Ok(producto, "Producto guardado correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Producto>.Error(
                    "Error de base de datos al guardar el producto: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Producto>.Error(
                    "Error inesperado al guardar el producto: " + ex.Message);
            }
        }

        /// <summary>Elimina logicamente un producto</summary>
        public ResultadoOperacion<Producto> Eliminar(int id)
        {
            try
            {
                var prod = _productoRepo.ObtenerPorId(id);
                if (prod == null)
                    return ResultadoOperacion<Producto>.Error("Producto no encontrado.");

                _productoRepo.EliminarLogico(id);
                return ResultadoOperacion<Producto>.Ok(prod, "Producto eliminado correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Producto>.Error(
                    "Error de base de datos al eliminar el producto: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Producto>.Error(
                    "Error inesperado al eliminar el producto: " + ex.Message);
            }
        }

        /// <summary>Restaura un producto si su categoria y suplidor están activos</summary>
        public ResultadoOperacion<Producto> Restaurar(int id)
        {
            try
            {
                var prod = _productoRepo.ObtenerPorId(id);
                if (prod == null)
                    return ResultadoOperacion<Producto>.Error("Producto no encontrado.");

                var cat = _categoriaRepo.ObtenerPorId(prod.CategoriaId);
                if (cat == null || !cat.Activo)
                    return ResultadoOperacion<Producto>.Error(
                        "No se puede restaurar: la categoria asociada está inactiva o no existe.");

                var sup = _suplidorRepo.ObtenerPorId(prod.SuplidorId);
                if (sup == null || !sup.Activo)
                    return ResultadoOperacion<Producto>.Error(
                        "No se puede restaurar: el suplidor asociado esta inactivo o no existe.");

                _productoRepo.Restaurar(id);
                return ResultadoOperacion<Producto>.Ok(prod, "Producto restaurado correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Producto>.Error(
                    "Error de base de datos al restaurar el producto: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Producto>.Error(
                    "Error inesperado al restaurar el producto: " + ex.Message);
            }
        }


        public object ProductosPorCategoria()
        {
            try
            {
                var categorias = _categoriaRepo.ObtenerTodos()
                                                 .ToDictionary(c => c.Id, c => c.Nombre);

                return _productoRepo.ObtenerActivos()
                    .GroupBy(p => p.CategoriaId)
                    .Select(g => new
                    {
                        Categoria = categorias.TryGetValue(g.Key, out var nombre)
                                    ? nombre
                                    : $"Cat #{g.Key}",
                        Cantidad = g.Count()
                    })
                    .OrderByDescending(x => x.Cantidad)
                    .ToList();
            }
            catch (SqlException ex) { Logger.Log(ex); return new List<object>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<object>(); }
        }

        public object Top5Suplidores()
        {
            try
            {
                var suplidores = _suplidorRepo.ObtenerTodos()
                                              .ToDictionary(s => s.Id, s => s.NombreEmpresa);

                return _productoRepo.ObtenerActivos()
                    .GroupBy(p => p.SuplidorId)
                    .Select(g => new
                    {
                        Suplidor = suplidores.TryGetValue(g.Key, out var nombre)
                                   ? nombre
                                   : $"Sup #{g.Key}",
                        TotalProductos = g.Count()
                    })
                    .OrderByDescending(x => x.TotalProductos)
                    .Take(5)
                    .ToList();
            }
            catch (SqlException ex) { Logger.Log(ex); return new List<object>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<object>(); }
        }


        public List<Producto> ProductosPorCategoriaYRango(int categoriaId, decimal min, decimal max)
        {
            try
            {
                return _productoRepo.ObtenerActivos()
                    .Where(p => (categoriaId == 0 || p.CategoriaId == categoriaId)
                                && p.Precio >= min && p.Precio <= max)
                    .ToList();
            }
            catch (SqlException ex) { Logger.Log(ex); return new List<Producto>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<Producto>(); }
        }

        public List<Producto> Buscar(string texto)
        {
            try
            {
                var t = (texto ?? "").Trim().ToLowerInvariant();
                return _productoRepo.ObtenerActivos()
                    .Where(p => t.Length == 0 || (p.Nombre ?? "").ToLower().Contains(t))
                    .ToList();
            }
            catch (SqlException ex) { Logger.Log(ex); return new List<Producto>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<Producto>(); }
        }

        public object PromedioPorCategoria()
        {
            try
            {
                var categorias = _categoriaRepo.ObtenerTodos()
                                                 .ToDictionary(c => c.Id, c => c.Nombre);

                return _productoRepo.ObtenerActivos()
                    .GroupBy(p => p.CategoriaId)
                    .Select(g => new
                    {
                        Categoria = categorias.TryGetValue(g.Key, out var nombre)
                                    ? nombre
                                    : $"Cat #{g.Key}",
                        PromedioPrecio = Math.Round(g.Average(p => p.Precio), 2),
                        Cantidad = g.Count()
                    })
                    .OrderByDescending(x => x.PromedioPrecio)
                    .ToList();
            }
            catch (SqlException ex) { Logger.Log(ex); return new List<object>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<object>(); }
        }
    }
}
