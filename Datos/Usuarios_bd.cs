using Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Usuarios_bd
    {
        private Conexion c;

        public Usuarios_bd()
        {
            c = new Conexion();
        }

        public DataTable Select()
        {
            string sql = "select id_usuarios,nombre,apellido1,apellido2 from usuarios;";
            DataTable datos = new DataTable();
            if (c.getConexion().conexionMSSQL == null)
            {
                SqlCommand cmd = new SqlCommand(sql, c.getConexion().conexionMSSQL);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand(sql, c.getConexion().conexionMySQL);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            return datos;
        }

        public void Insert(Usuarios u)
        {

        }

        public void Update(Usuarios u)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
