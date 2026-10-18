using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    /// <summary>
    /// Implementación base generica de IRepositorio&lt;T&gt;.
    /// Provee ObtenerActivos, EliminarLogico y Restaurar de forma genérica.
    /// </summary>
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : EntidadBase
    {
        /// <summary>Nombre físico de la tabla en la base de datos</summary>
        protected abstract string NombreTabla { get; }

        /// <summary>Mapea una fila del reader a una entidad T</summary>
        protected abstract T MapearDesdeReader(SqlDataReader reader);

        /// <summary>Devuelve todos los registros de la entidad</summary>
        public abstract List<T> ObtenerTodos();

        /// <summary>Devuelve un registro por su Id (o null si no existe).</summary>
        public abstract T ObtenerPorId(int id);

        /// <summary>Inserta un nuevo registr</summary>
        public abstract void Insertar(T entidad);

        /// <summary>Actualiz un registro existente</summary>
        public abstract void Actualizar(T entidad);

        /// <summary>Devuelve solo los registros activos</summary>
        public virtual List<T> ObtenerActivos() => ObtenerTodos().Where(x => x.Activo).ToList();

        /// <summary>Marca un registro como inactivo</summary>
        public virtual void EliminarLogico(int id)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    $"UPDATE {NombreTabla} SET Activo = 0, FechaModificacion = @fecha WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        /// <summary>Restaura un registro eliminado logicamente</summary>
        public virtual void Restaurar(int id)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    $"UPDATE {NombreTabla} SET Activo = 1, FechaModificacion = @fecha WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }
    }
}
