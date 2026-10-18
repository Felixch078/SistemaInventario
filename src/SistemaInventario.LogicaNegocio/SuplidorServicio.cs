using Microsoft.Data.SqlClient;
using SistemaInventario.AccesoDatos;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SistemaInventario.LogicaNegocio
{
    /// <summary>
    /// Servicio de negocio para Suplidores con validaciones de formato
    /// </summary>
    public class SuplidorServicio : ISuplidorServicio
    {
        private static readonly Regex _regexTelefono =
            new Regex(@"^(809|829|849)-\d{3}-\d{4}$", RegexOptions.Compiled);

        private static readonly Regex _regexEmail =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private readonly IRepositorio<Suplidor> _suplidorRepo;
        private readonly IRepositorio<Producto> _productoRepo;

        /// <summary>
        /// Crea una instancia del servicio inyectando sus repositorios
        /// </summary>
        public SuplidorServicio(IRepositorio<Suplidor> suplidorRepo,
                                IRepositorio<Producto> productoRepo)
        {
            _suplidorRepo = suplidorRepo ?? throw new ArgumentNullException(nameof(suplidorRepo));
            _productoRepo = productoRepo ?? throw new ArgumentNullException(nameof(productoRepo));
        }

        /// <summary>Devuelve todos los suplidores (activos e inactivos)</summary>
        public List<Suplidor> Listar()
        {
            try { return _suplidorRepo.ObtenerTodos(); }
            catch (SqlException ex) { Logger.Log(ex); return new List<Suplidor>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<Suplidor>(); }
        }

        /// <summary>Devuelve solo los suplidores activos</summary>
        public List<Suplidor> ListarActivos()
        {
            try { return _suplidorRepo.ObtenerActivos(); }
            catch (SqlException ex) { Logger.Log(ex); return new List<Suplidor>(); }
            catch (Exception ex) { Logger.Log(ex); return new List<Suplidor>(); }
        }

        /// <summary>Obtiene un suplidor por Id</summary>
        public Suplidor ObtenerPorId(int id)
        {
            try { return _suplidorRepo.ObtenerPorId(id); }
            catch (SqlException ex) { Logger.Log(ex); return null; }
            catch (Exception ex) { Logger.Log(ex); return null; }
        }

        /// <summary>Valida y guarda un suplidor</summary>
        public ResultadoOperacion<Suplidor> Guardar(Suplidor suplidor)
        {
            if (suplidor == null)
                return ResultadoOperacion<Suplidor>.Error("El suplidor no puede ser nulo.");

            var empresa = (suplidor.NombreEmpresa ?? "").Trim();
            if (empresa.Length == 0)
                return ResultadoOperacion<Suplidor>.Error("El nombre de la empresa es obligatorio.");
            if (empresa.Length > 150)
                return ResultadoOperacion<Suplidor>.Error("El nombre de la empresa no puede superar 150 caracteres.");

            var contacto = (suplidor.NombreContacto ?? "").Trim();
            if (contacto.Length == 0)
                return ResultadoOperacion<Suplidor>.Error("El nombre del contacto es obligatorio.");

            var telefono = (suplidor.Telefono ?? "").Trim();
            if (!_regexTelefono.IsMatch(telefono))
                return ResultadoOperacion<Suplidor>.Error("El teléfono debe tener formato 809/829/849-XXX-XXXX.");

            var email = (suplidor.Email ?? "").Trim();
            if (!_regexEmail.IsMatch(email))
                return ResultadoOperacion<Suplidor>.Error("El correo electrónico no tiene un formato válido.");

            var sitioWeb = string.IsNullOrWhiteSpace(suplidor.SitioWeb) ? null : suplidor.SitioWeb.Trim();
            if (sitioWeb != null)
            {
                if (!Uri.TryCreate(sitioWeb, UriKind.Absolute, out var uri) ||
                    (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                    return ResultadoOperacion<Suplidor>.Error("El sitio web debe ser una URL válida (http o https).");
            }

            try { 
            
                var todos = _suplidorRepo.ObtenerTodos();
                if (todos.Any(s => s.Id != suplidor.Id && s.Activo &&
                                   string.Equals(s.NombreEmpresa, empresa, StringComparison.OrdinalIgnoreCase)))
                    return ResultadoOperacion<Suplidor>.Error(
                        "Ya existe un suplidor activo con ese nombre de empresa.");

                suplidor.NombreEmpresa = empresa;
                suplidor.NombreContacto = contacto;
                suplidor.Telefono = telefono;
                suplidor.Email = email;
                suplidor.SitioWeb = sitioWeb;

                if (suplidor.Id == 0)
                {
                    suplidor.Activo = true;
                    suplidor.FechaCreacion = DateTime.Now;
                    suplidor.FechaModificacion = DateTime.Now;
                    _suplidorRepo.Insertar(suplidor);
                }
                else
                {
                    suplidor.FechaModificacion = DateTime.Now;
                    _suplidorRepo.Actualizar(suplidor);
                }

                return ResultadoOperacion<Suplidor>.Ok(suplidor, "Suplidor guardado correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Suplidor>.Error(
                    "Error de base de datos al guardar el suplidor: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Suplidor>.Error(
                    "Error inesperado al guardar el suplidor: " + ex.Message);
            }
        }

        /// <summary>Elimina lógicamente un suplidor si no tiene productos activos asociados</summary>
        public ResultadoOperacion<Suplidor> Eliminar(int id)
        {
            try
            {
                var sup = _suplidorRepo.ObtenerPorId(id);
                if (sup == null)
                    return ResultadoOperacion<Suplidor>.Error("Suplidor no encontrado.");

                var productos = _productoRepo.ObtenerActivos();
                if (productos.Any(p => p.SuplidorId == id))
                    return ResultadoOperacion<Suplidor>.Error(
                        "No se puede eliminar: hay productos activos asociados a este suplidor.");

                _suplidorRepo.EliminarLogico(id);
                return ResultadoOperacion<Suplidor>.Ok(sup, "Suplidor eliminado correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Suplidor>.Error(
                    "Error de base de datos al eliminar el suplidor: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Suplidor>.Error(
                    "Error inesperado al eliminar el suplidor: " + ex.Message);
            }
        }

        /// <summary>Restaura un suplidor previamente eliminado</summary>
        public ResultadoOperacion<Suplidor> Restaurar(int id)
        {
            try
            {
                var sup = _suplidorRepo.ObtenerPorId(id);
                if (sup == null)
                    return ResultadoOperacion<Suplidor>.Error("Suplidor no encontrado.");

                _suplidorRepo.Restaurar(id);
                return ResultadoOperacion<Suplidor>.Ok(sup, "Suplidor restaurado correctamente.");
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Suplidor>.Error(
                    "Error de base de datos al restaurar el suplidor: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return ResultadoOperacion<Suplidor>.Error(
                    "Error inesperado al restaurar el suplidor: " + ex.Message);
            }
        }
    }
}
