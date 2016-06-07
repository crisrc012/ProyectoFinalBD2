using Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Usuarios_bd
    {
        private Conexion c;
        bool mysql;

        public Usuarios_bd(bool mysql = false)
        {
            this.mysql = mysql;
            c = new Conexion(mysql);
        }

        public DataTable Select()
        {
            string sql = "select id_usuarios,nombre,apellido1,apellido2 from usuarios;";
            DataTable datos = new DataTable();
            if (!mysql)
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

        private void insert_update(string sql, Usuarios u)
        {
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(null, c.getConexion().conexionMSSQL);
                cmd.CommandText = sql;
                cmd.Parameters.Add("@id_usuarios", SqlDbType.Int).Value = u.id_usuarios;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = u.nombre;
                cmd.Parameters.Add("@apellido1", SqlDbType.VarChar).Value = u.apellido1;
                cmd.Parameters.Add("@apellido2", SqlDbType.VarChar).Value = u.apellido2;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Console.Write(ex.Message);
                }
                finally
                {
                    c.getConexion().conexionMSSQL.Close();
                }
            }
            else
            {
                c.getConexion().conexionMySQL.Open();
                MySqlCommand cmd = new MySqlCommand(null, c.getConexion().conexionMySQL);
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id_usuarios", SqlDbType.Int).Value = u.id_usuarios;
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = u.nombre;
                cmd.Parameters.AddWithValue("@apellido1", SqlDbType.VarChar).Value = u.apellido1;
                cmd.Parameters.AddWithValue("@apellido2", SqlDbType.VarChar).Value = u.apellido2;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    System.Console.Write(ex.Message);
                }
                finally
                {
                    c.getConexion().conexionMySQL.Close();
                }
            }
        }

        public void Insert(Usuarios u)
        {
            string sql = "insert into usuarios (id_usuarios,nombre,apellido1,apellido2) "
                    + "values(@id_usuarios, @nombre, @apellido1, @apellido2);";
            insert_update(sql, u);
        }

        public void Update(Usuarios u)
        {
            string sql = "update usuarios set "
                + "nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2"
                + "where id_usuarios = @id_usuarios;";
            insert_update(sql, u);
        }

        public void Delete(int id)
        {
            string sql = "delete usuarios where id_usuarios = @id_usuarios;";
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(null, c.getConexion().conexionMSSQL);
                cmd.CommandText = sql;
                cmd.Parameters.Add("@id_usuarios", SqlDbType.Int).Value = id;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Console.Write(ex.Message);
                }
                finally
                {
                    c.getConexion().conexionMSSQL.Close();
                }
            }
            else
            {
                c.getConexion().conexionMySQL.Open();
                MySqlCommand cmd = new MySqlCommand(null, c.getConexion().conexionMySQL);
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id_usuarios", SqlDbType.Int).Value = id;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    System.Console.Write(ex.Message);
                }
                finally
                {
                    c.getConexion().conexionMySQL.Close();
                }
            }
        }
    }
}
