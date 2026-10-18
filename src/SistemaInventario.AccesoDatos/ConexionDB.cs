using Microsoft.Data.SqlClient;

namespace SistemaInventario.AccesoDatos
{
    /// <summary>
    /// Aqui se usa el patron singleton que se encarga de proveer conexiones a la base de datos.
    /// </summary>
    public sealed class ConexionDb
    {
        private static readonly Lazy<ConexionDb> _instancia =
            new Lazy<ConexionDb>(() => new ConexionDb());

        /// <summary>Instancia unica de la clase</summary>
        public static ConexionDb Instance => _instancia.Value;

        private readonly string _cadenaConexion;

        private ConexionDb()
        {
            _cadenaConexion = @"Server=DESKTOP-QPRRR2N;Database=SistemaInventario;User Id=sa;Password=contraseña;TrustServerCertificate=true;";
        }

        /// <summary>abre y devuelve una nueva conexion a la base de datos</summary>
        public SqlConnection ObtenerConexion()
        {
            var conex = new SqlConnection(_cadenaConexion);
            conex.Open();
            return conex;
        }
    }
}
