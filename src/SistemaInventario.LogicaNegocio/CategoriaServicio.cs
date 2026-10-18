using Microsoft.Data.SqlClient;
using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    /// <summary>Servicio de negocio para Categorias con validaciones y reglas asociadas</summary>
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IRepositorio<Categoria> _categoriaRepo;
        private readonly IRepositorio<Producto> _productoRepo;

        /// <summary> Crea una instancia del servicio inyectando sus repositorios </summary>
        public CategoriaServicio(IRepositorio<Categoria> categoriaRepo,
                                 IRepositorio<Producto> productoRepo)
        {
            _categoriaRepo = categoriaRepo ?? throw new ArgumentNullException(nameof(categoriaRepo));
            _productoRepo = productoRepo ?? throw new ArgumentNullException(nameof(productoRepo));
        }

        /// <summary>Devuelve todas las categorias esten activas o inactivas</summary>
        public List<Categoria> Listar()
        {
            try { return _categoriaRepo.ObtenerTodos(); }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return new List<Categoria>();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Categoria>();
            }
        }

        /// <summary>Devuelve solo las categorias activas</summary>
        public List<Categoria> ListarActivos()
        {
            try { return _categoriaRepo.ObtenerActivos(); }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return new List<Categoria>();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return new List<Categoria>();
            }
        }

        /// <summary>Obtiene una categoria por id</summary>
        public Categoria ObtenerPorId(int id)
        {
            try { return _categoriaRepo.ObtenerPorId(id); }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return null;
            }
        }

        /// <summary>Valida y guarda una categoria</summary>
        public ResultadoOperacion<Categoria> Guardar(Categoria categoria)
        {
            if (categoria == null)
                return ResultadoOperacion<Categoria>.Error("La categoria no puede ser nula.");

            var nombre = (categoria.Nombre ?? "").Trim();
            if (nombre.Length < 3 || nombre.Length > 100)
                return ResultadoOperacion<Categoria>.Error("El nombre debe tener entre 3 y 100 caracteres.");

            var descripcion = (categoria.Descripcion ?? "").Trim();
            if (descripcion.Length == 0)
                return ResultadoOperacion<Categoria>.Error("La descripcion es obligatoria.");
            if (descripcion.Length > 500)
                return ResultadoOperacion<Categoria>.Error("La descripcion no puede superar los 500 caracteres.");

            var fotos = categoria.RutasFotos ?? new List<string>();
            if (fotos.Count > 5)
                return ResultadoOperacion<Categoria>.Error("Máximo 5 fotos por categoria.");

            foreach (var ruta in fotos)
            {
                if (string.IsNullOrWhiteSpace(ruta))
                    return ResultadoOperacion<Categoria>.Error("Hay una ruta de foto vacia.");

                var ext = Path.GetExtension(ruta)?.ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                    return ResultadoOperacion<Categoria>.Error(
                        $"Solo se permiten fotos .jpg, .jpeg o .png. Archivo invalido: {Path.GetFileName(ruta)}");

                if (File.Exists(ruta) && new FileInfo(ruta).Length > 2 * 1024 * 1024)
                    return ResultadoOperacion<Categoria>.Error(
                        $"La foto '{Path.GetFileName(ruta)}' supera los 2 MB.");
            }

            try
            {
                var todas = _categoriaRepo.ObtenerTodos();
                if (todas.Any(c => c.Id != categoria.Id && c.Activo &&
                                   string.Equals(c.Nombre, nombre, StringComparison.OrdinalIgnoreCase)))
                    return ResultadoOperacion<Categoria>.Error("Ya existe una categoría activa con ese nombre.");

                categoria.Nombre = nombre;
                categoria.Descripcion = descripcion;
                categoria.RutasFotos = fotos;

                if (categoria.Id == 0)
                {
                    categoria.Activo = true;
                    categoria.FechaCreacion = DateTime.Now;
                    categoria.FechaModificacion = DateTime.Now;
                    _categoriaRepo.Insertar(categoria);
                }
                else
                {
                    categoria.FechaModificacion = DateTime.Now;
                    _categoriaRepo.Actualizar(categoria);
                }

                return ResultadoOperacion<Categoria>.Ok(categoria, "Categoria guardada correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Categoria>.Error(
                    "Error de base de datos al guardar la categoria: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Categoria>.Error(
                    "Error inesperado al guardar la categoria: " + ex.Message);
            }
        }

        /// <summary>Elimina logicamente una categoría si no tiene ningun producto activo asociados.</summary>
        public ResultadoOperacion<Categoria> Eliminar(int id)
        {
            try
            {
                var cat = _categoriaRepo.ObtenerPorId(id);
                if (cat == null)
                    return ResultadoOperacion<Categoria>.Error("Categoria no encontrada.");

                var productos = _productoRepo.ObtenerActivos();
                if (productos.Any(p => p.CategoriaId == id))
                    return ResultadoOperacion<Categoria>.Error(
                        "No se puede eliminar: hay productos activos asociados a esta categoría.");

                _categoriaRepo.EliminarLogico(id);
                return ResultadoOperacion<Categoria>.Ok(cat, "Categoria eliminada correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Categoria>.Error(
                    "Error de base de datos al eliminar la categoria: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Categoria>.Error(
                    "Error inesperado al eliminar la categoria: " + ex.Message);
            }
        }

        /// <summary>Restaura una categoría que fue eliminada previamente</summary>
        public ResultadoOperacion<Categoria> Restaurar(int id)
        {
            try
            {
                var cat = _categoriaRepo.ObtenerPorId(id);
                if (cat == null)
                    return ResultadoOperacion<Categoria>.Error("Categoria no encontrada.");

                _categoriaRepo.Restaurar(id);
                return ResultadoOperacion<Categoria>.Ok(cat, "Categoria restaurada correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Categoria>.Error(
                    "Error de base de datos al restaurar la categoria: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Categoria>.Error(
                    "Error inesperado al restaurar la categoria: " + ex.Message);
            }
        }
    }
}
