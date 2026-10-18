using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    /// <summary>Repositorio ADO.NET para la entidad Producto</summary>
    public class ProductoRepositorio : RepositorioBase<Producto>, IProductoRepositorio
    {
        protected override string NombreTabla => "Producto";

        /// <summary>Devuelve todos los productos</summary>
        public override List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT Id, Nombre, Precio, CategoriaId, SuplidorId, Activo, " +
                    "FechaCreacion, FechaModificacion FROM Producto", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) lista.Add(MapearDesdeReader(reader));
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
            return lista;
        }

        /// <summary>Devuelve un producto por Id</summary>
        public override Producto ObtenerPorId(int id)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT Id, Nombre, Precio, CategoriaId, SuplidorId, Activo, " +
                    "FechaCreacion, FechaModificacion FROM Producto WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? MapearDesdeReader(reader) : null;
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        /// <summary>Inserta un producto</summary>
        public override void Insertar(Producto entidad)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    @"INSERT INTO Producto (Nombre, Precio, CategoriaId, SuplidorId, Activo,
                                            FechaCreacion, FechaModificacion)
                      VALUES (@Nombre, @Precio, @CategoriaId, @SuplidorId, @Activo,
                              @FechaCreacion, @FechaModificacion);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    AgregarParametros(cmd, entidad);
                    entidad.Id = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        /// <summary>Actualiza un producto</summary>
        public override void Actualizar(Producto entidad)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    @"UPDATE Producto SET Nombre = @Nombre, Precio = @Precio, CategoriaId = @CategoriaId,
                                          SuplidorId = @SuplidorId, Activo = @Activo,
                                          FechaModificacion = @FechaModificacion
                      WHERE Id = @Id;", conn))
                {
                    AgregarParametros(cmd, entidad);
                    cmd.Parameters.AddWithValue("@Id", entidad.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        /// <summary>mapea una fila de Producto a la entidad.</summary>
        protected override Producto MapearDesdeReader(SqlDataReader reader)
        {
            return new Producto
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Precio = reader.GetDecimal(2),
                CategoriaId = reader.GetInt32(3),
                SuplidorId = reader.GetInt32(4),
                Activo = reader.GetBoolean(5),
                FechaCreacion = reader.GetDateTime(6),
                FechaModificacion = reader.GetDateTime(7)
            };
        }

        private void AgregarParametros(SqlCommand cmd, Producto p)
        {
            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@Precio", p.Precio);
            cmd.Parameters.AddWithValue("@CategoriaId", p.CategoriaId);
            cmd.Parameters.AddWithValue("@SuplidorId", p.SuplidorId);
            cmd.Parameters.AddWithValue("@Activo", p.Activo);
            if (p.Id == 0) cmd.Parameters.AddWithValue("@FechaCreacion", p.FechaCreacion);
            cmd.Parameters.AddWithValue("@FechaModificacion", p.FechaModificacion);
        }
    }
}
