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
            string servidor = @"localhost\U"; // @"PAGUIMENDEZ\SQL2014N1"; 
            string bd = "proyectofinal";
            string usuario = "user1";
            string contrasena = "Abc1234";
            c = new Conexiones();
            // Conexion para SQL Server
            if (!mysql)
            {
                cadenaConexion = "Data Source = " + servidor 
                    + "; Initial Catalog =" + bd 
                    + "; Integrated Security = True";


                c.conexionMSSQL = new SqlConnection(cadenaConexion);
            }
            // Conexion para MySQL
            else
            {
                cadenaConexion = "SERVER = " + servidor + ";" 
                    + "DATABASE = " + bd + ";"
                    + "UID = " + usuario + ";" 
                    + "PASSWORD = " + contrasena + ";port=3306;charset=utf8";
                c.conexionMySQL = new MySqlConnection(cadenaConexion);
            }
        }

        public Conexiones getConexion()
        {
            return c;
        }
    }
}
