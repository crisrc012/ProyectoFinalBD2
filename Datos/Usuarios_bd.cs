using Entidades;
using MySql.Data.MySqlClient;
using System;
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

        public DataTable Select(int? id_usuarios = null, int? cedula = null, int? id_rol = null, string username = null)
        {
            DataTable datos = new DataTable();
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                string sql = 
                    "EXEC sp_usuarios @id_usuarios,@cedula,@id_rol,@username;";
                SqlCommand cmd = new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@id_usuarios", SqlDbType.Int).Value = 
                    (object)id_usuarios ?? DBNull.Value;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = 
                    (object)cedula ?? DBNull.Value;
                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = 
                    (object)id_rol ?? DBNull.Value;
                cmd.Parameters.Add("@username", SqlDbType.Int).Value = 
                    (object)username ?? DBNull.Value;
                cmd.Prepare();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            else
            {
                c.getConexion().conexionMySQL.Open();
                string sql = 
                    "CALL `proyectofinal`.`sp_usuarios`(@id_usuarios,@cedula,@id_rol,@username);";
                MySqlCommand cmd = 
                    new MySqlCommand(sql, c.getConexion().conexionMySQL);
                cmd.Parameters.AddWithValue("@id_usuarios", SqlDbType.Int).Value = 
                    (object)id_usuarios ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@cedula", SqlDbType.Int).Value = 
                    (object)cedula ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@id_rol", SqlDbType.Int).Value = 
                    (object)id_rol ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@username", SqlDbType.Int).Value = 
                    (object)username ?? DBNull.Value;
                cmd.Prepare();
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
                SqlCommand cmd = 
                    new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = 
                    (object)u.cedula ?? DBNull.Value;
                cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = 
                    (object)u.id_rol ?? DBNull.Value;
                cmd.Parameters.Add("@username", SqlDbType.VarChar,10).Value = 
                    (object)u.username ?? DBNull.Value;
                cmd.Parameters.Add("@contraseña", SqlDbType.VarChar,15).Value = 
                    (object)u.contraseña ?? DBNull.Value;
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
                sql = "CALL `proyectofinal`.`sp_insert_usuarios`(@cedula,@id_rol,@username,@contraseña);";
                c.getConexion().conexionMySQL.Open();
                MySqlCommand cmd = 
                    new MySqlCommand(sql, c.getConexion().conexionMySQL);
                cmd.Parameters.AddWithValue("@cedula",(object)u.cedula ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id_rol",(object)u.id_rol ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@username",(object)u.username ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@contraseña",(object)u.contraseña ?? DBNull.Value);
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
            string sql = "exec sp_insert_usuarios @cedula, @id_rol, @username, @contraseña;";
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
                SqlCommand cmd = 
                    new SqlCommand(sql, c.getConexion().conexionMSSQL);
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
                MySqlCommand cmd = 
                    new MySqlCommand(sql, c.getConexion().conexionMySQL);
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
