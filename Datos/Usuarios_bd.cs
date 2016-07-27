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
            string sql = "exec sp_usuarios null,null,null,null;";
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
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = u.cedula;
                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = u.id_rol;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = u.username;
                cmd.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = u.contraseña;
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
                cmd.Parameters.AddWithValue("@cedula", SqlDbType.Int).Value = u.cedula;
                cmd.Parameters.AddWithValue("@id_rol", SqlDbType.Int).Value = u.id_rol;
                cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = u.username;
                cmd.Parameters.AddWithValue("@contraseña", SqlDbType.VarChar).Value = u.contraseña;
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
            string sql = "insert into usuarios (cedula,id_rol,username,contraseña) "
                    + "values(@cedula, @id_rol, @username, @contraseña);";
            insert_update(sql, u);
        }

        public void Update(Usuarios u)
        {
            string sql = "update usuarios set "
                + "username = @username, contraseña = @contraseña"
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
