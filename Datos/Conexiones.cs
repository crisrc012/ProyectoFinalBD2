using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexiones
    {
        public SqlConnection conexionMSSQL { get; set; }
        public MySqlConnection conexionMySQL { get; set; }
    }
}
