using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        private Conexiones c;
        private string cadenaConexion;

        public Conexion(bool mysql = false)
        {
            // Parametros de los servidores de base de datos
            string servidor = "localhost";
            string bd = "ProyectoFinal";
            string usuario = "";
            string contrasena = "";
            c = new Conexiones();
            // Conexion para SQL Server
            if (!mysql)
            {
                cadenaConexion = "Data Source = " + servidor 
                    + @"\SQLEXPRESS; Initial Catalog = " + bd 
                    + "; User ID=" + usuario 
                    + ";Password=" + contrasena + ";";
                c.conexionMSSQL = new SqlConnection(cadenaConexion);
            }
            // Conexion para MySQL
            else
            {
                cadenaConexion = "SERVER = " + servidor + ";" 
                    + "DATABASE = " + bd + ";"
                    + "UID = " + usuario + ";" 
                    + "PASSWORD = " + contrasena + ";";
                c.conexionMySQL = new MySqlConnection(cadenaConexion);
            }
        }

        public Conexiones getConexion()
        {
            return c;
        }
    }
}
