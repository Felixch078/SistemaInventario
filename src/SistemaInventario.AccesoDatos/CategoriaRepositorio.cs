using Microsoft.Data.SqlClient;
using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        protected override string NombreTabla => "Categoria";

        /// <summary>Se encarga de devolver todas las categorias con sus fotos</summary>
        public override List<Categoria> ObtenerTodos()
        {
            var lista = new List<Categoria>();
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                {
                    using (var cmd = new SqlCommand(
                        "SELECT Id, Nombre, Descripcion, Activo, FechaCreacion, FechaModificacion " +
                        "FROM Categoria", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) lista.Add(MapearDesdeReader(reader));
                    }

                    foreach (var cat in lista)
                        cat.RutasFotos = ObtenerFotos(cat.Id, conn);
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
            return lista;
        }

        /// <summary>Se encatga de devolver la categoria con fotos por id</summary>
        public override Categoria ObtenerPorId(int id)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                {
                    Categoria cat = null;
                    using (var cmd = new SqlCommand(
                        "SELECT Id, Nombre, Descripcion, Activo, FechaCreacion, FechaModificacion " +
                        "FROM Categoria WHERE Id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) cat = MapearDesdeReader(reader);
                        }
                    }
                    if (cat != null)
                        cat.RutasFotos = ObtenerFotos(cat.Id, conn);
                    return cat;
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        /// /// <summary>Inserta una categoria y sus fotos</summary>
        public override void Insertar(Categoria entidad)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        var sql = @"INSERT INTO Categoria 
                                    (Nombre, Descripcion, Activo, FechaCreacion, FechaModificacion)
                                    VALUES (@Nombre, @Descripcion, @Activo, @FechaCreacion, @FechaModificacion);
                                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                        using (var cmd = new SqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                            cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                            cmd.Parameters.AddWithValue("@Activo", entidad.Activo);
                            cmd.Parameters.AddWithValue("@FechaCreacion", entidad.FechaCreacion);
                            cmd.Parameters.AddWithValue("@FechaModificacion", entidad.FechaModificacion);
                            entidad.Id = (int)cmd.ExecuteScalar();
                        }
                        InsertarFotos(entidad.Id, entidad.RutasFotos, conn, tx);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        /// <summary>Actualiza una categoria y reescribe sus fotos</summary>
        public override void Actualizar(Categoria entidad)
        {
            try
            {
                using (var conn = ConexionDb.Instance.ObtenerConexion())
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        var sql = @"UPDATE Categoria 
                                    SET Nombre = @Nombre, Descripcion = @Descripcion,
                                        Activo = @Activo, FechaModificacion = @FechaModificacion
                                    WHERE Id = @Id;";
                        using (var cmd = new SqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                            cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                            cmd.Parameters.AddWithValue("@Activo", entidad.Activo);
                            cmd.Parameters.AddWithValue("@FechaModificacion", entidad.FechaModificacion);
                            cmd.Parameters.AddWithValue("@Id", entidad.Id);
                            cmd.ExecuteNonQuery();
                        }

                        using (var del = new SqlCommand("DELETE FROM CategoriaFoto WHERE CategoriaId = @id", conn, tx))
                        {
                            del.Parameters.AddWithValue("@id", entidad.Id);
                            del.ExecuteNonQuery();
                        }
                        InsertarFotos(entidad.Id, entidad.RutasFotos, conn, tx);
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.Log(ex);
                throw;
            }
        }

        /// <summary>Esta parte mapea una fila de la tabla Categoria a la entidad</summary>
        protected override Categoria MapearDesdeReader(SqlDataReader reader)
        {
            return new Categoria
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Descripcion = reader.GetString(2),
                Activo = reader.GetBoolean(3),
                FechaCreacion = reader.GetDateTime(4),
                FechaModificacion = reader.GetDateTime(5)
            };
        }

        private List<string> ObtenerFotos(int categoriaId, SqlConnection conn)
        {
            var fotos = new List<string>();
            using (var cmd = new SqlCommand(
                "SELECT Ruta FROM CategoriaFoto WHERE CategoriaId = @id ORDER BY Id", conn))
            {
                cmd.Parameters.AddWithValue("@id", categoriaId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) fotos.Add(reader.GetString(0));
                }
            }
            return fotos;
        }

        private void InsertarFotos(int categoriaId, List<string> rutas, SqlConnection conn, SqlTransaction tx)
        {
            if (rutas == null || rutas.Count == 0) return;
            foreach (var ruta in rutas)
            {
                using (var cmd = new SqlCommand(
                    "INSERT INTO CategoriaFoto (CategoriaId, Ruta) VALUES (@cat, @ruta)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@cat", categoriaId);
                    cmd.Parameters.AddWithValue("@ruta", ruta);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
