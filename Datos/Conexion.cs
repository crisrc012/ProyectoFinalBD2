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
            string instancia = "U"; // "SQL2014N1"
            string bd = "proyectofinal";
            string usuario = "user1";
            string contrasena = "Abc1234";
            c = new Conexiones();
            if (!mysql)
            {
                // Conexion para SQL Server
                if (instancia != null)
                {
                    servidor += @"\" + instancia;
                }
                cadenaConexion = "Data Source=" + servidor 
                    + "; Initial Catalog=" + bd 
                    + "; User Id=" + usuario 
                    + "; Password=" + contrasena 
                    + ";" ;
                c.conexionMSSQL = new SqlConnection(cadenaConexion);
            }
            else
            {
                // Conexion para MySQL
                cadenaConexion = "SERVER = " + servidor +";" 
                    + "DATABASE = " + bd + ";"
                    + "UID = " + usuario + ";" 
                    + "PASSWORD = " + contrasena 
                    + ";port=3306;charset=utf8";
                c.conexionMySQL = new MySqlConnection(cadenaConexion);
            }
        }

        public Conexiones getConexion()
        {
            return c;
        }
    }
}
