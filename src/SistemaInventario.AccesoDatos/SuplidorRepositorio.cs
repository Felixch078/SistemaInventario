using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    public class SuplidorRepositorio : RepositorioBase<Suplidor>, ISuplidorRepositorio
    {
        protected override string NombreTabla => "Suplidor";

        /// <summary>devuelve todos los suplidores</summary>
        public override List<Suplidor> ObtenerTodos()
        {
            var lista = new List<Suplidor>();
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT Id, NombreEmpresa, NombreContacto, Telefono, Email, SitioWeb, " +
                    "Activo, FechaCreacion, FechaModificacion FROM Suplidor", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) lista.Add(MapearDesdeReader(reader));
                }
            }
            catch (SqlException excepcion)
            {
                Logger.Log(excepcion);
                throw;
            }
            return lista;
        }

        /// <summary>Devuelve un suplidor por Id</summary>
        public override Suplidor ObtenerPorId(int id)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "SELECT Id, NombreEmpresa, NombreContacto, Telefono, Email, SitioWeb, " +
                    "Activo, FechaCreacion, FechaModificacion FROM Suplidor WHERE Id = @id", conn))
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

        /// <summary>inserta un suplidor</summary>
        public override void Insertar(Suplidor entidad)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    @"INSERT INTO Suplidor (NombreEmpresa, NombreContacto, Telefono, Email, SitioWeb,
                                            Activo, FechaCreacion, FechaModificacion)
                      VALUES (@NombreEmpresa, @NombreContacto, @Telefono, @Email, @SitioWeb,
                              @Activo, @FechaCreacion, @FechaModificacion);
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

        /// <summary>actualiza un suplidor.</summary>
        public override void Actualizar(Suplidor entidad)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    @"UPDATE Suplidor SET NombreEmpresa = @NombreEmpresa, NombreContacto = @NombreContacto,
                                          Telefono = @Telefono, Email = @Email, SitioWeb = @SitioWeb,
                                          Activo = @Activo, FechaModificacion = @FechaModificacion
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

        /// <summary>mpea una fila de Suplidor a la entidad.</summary>
        protected override Suplidor MapearDesdeReader(SqlDataReader reader)
        {
            return new Suplidor
            {
                Id = reader.GetInt32(0),
                NombreEmpresa = reader.GetString(1),
                NombreContacto = reader.GetString(2),
                Telefono = reader.GetString(3),
                Email = reader.GetString(4),
                SitioWeb = reader.IsDBNull(5) ? null : reader.GetString(5),
                Activo = reader.GetBoolean(6),
                FechaCreacion = reader.GetDateTime(7),
                FechaModificacion = reader.GetDateTime(8)
            };
        }

        private void AgregarParametros(SqlCommand cmd, Suplidor s)
        {
            cmd.Parameters.AddWithValue("@NombreEmpresa", s.NombreEmpresa);
            cmd.Parameters.AddWithValue("@NombreContacto", s.NombreContacto);
            cmd.Parameters.AddWithValue("@Telefono", s.Telefono);
            cmd.Parameters.AddWithValue("@Email", s.Email);
            cmd.Parameters.AddWithValue("@SitioWeb", (object)s.SitioWeb ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Activo", s.Activo);
            if (s.Id == 0) cmd.Parameters.AddWithValue("@FechaCreacion", s.FechaCreacion);
            cmd.Parameters.AddWithValue("@FechaModificacion", s.FechaModificacion);
        }
    }
}
