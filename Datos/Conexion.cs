using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        private SqlConnection conexionMSSQL;
        private MySqlConnection conexionMySQL;
        private string cadenaConexion;
        private bool mysql;

        public Conexion(bool mysql = false)
        {
            this.mysql = mysql;
            string servidor = "localhost";
            string bd = "ProyectoFinal";
            string usuario = "";
            string contrasena = "";
            if (!mysql)
            {
                cadenaConexion = "Data Source = " + servidor + @"\SQLEXPRESS; Initial Catalog = " + bd + "; User ID=" + usuario + ";Password=" + contrasena + ";";
                conexionMSSQL = new SqlConnection(cadenaConexion);
            }
            else
            {
                cadenaConexion = "SERVER = " + servidor + ";" + "DATABASE = " + bd + ";" + "UID = " + usuario + ";" + "PASSWORD = " + contrasena + ";";
                conexionMySQL = new MySqlConnection(cadenaConexion);
            }
        }

        public SqlConnection getMSSQLConnection()
        {
            if (!this.mysql)
            {
                return conexionMSSQL;
            }
            else
            {
                return null;
            }
        }

        public MySqlConnection getMySQLConnection()
        {
            if (this.mysql)
            {
                return conexionMySQL;
            }
            else
            {
                return null;
            }
            
        }
    }
}
