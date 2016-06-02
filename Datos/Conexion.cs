using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        private SqlConnection conexionMSSQL;
        private MySqlConnection conexionMySQL;
        private string cadenaConexion;

        public Conexion()
        {
            cadenaConexion = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = ProyectoFinal; Integrated Security = true;";
            conexionMSSQL = new SqlConnection(cadenaConexion);
        }

        public SqlConnection getMSSQLConnection()
        {
            return conexionMSSQL;
        }

        public MySqlConnection getMySQLConnection()
        {
            return conexionMySQL;
        }
    }
}
