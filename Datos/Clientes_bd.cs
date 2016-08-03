using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Clientes_bd
    {
        private Conexion c;
        bool mysql;

        public Clientes_bd(bool mysql = false)
        {
            this.mysql = mysql;
            c = new Conexion(mysql);
        }

        public DataTable Select(int? id_cliente = null, int? cedula = null)
        {
            DataTable datos = new DataTable();
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                string sql = "EXEC sp_cliente @id_cliente,@cedula;";
                SqlCommand cmd = new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = (object) id_cliente ?? DBNull.Value;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = (object) cedula ?? DBNull.Value;
                cmd.Prepare();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            else
            {
                c.getConexion().conexionMySQL.Open();
                string sql = "CALL `proyectofinal`.`sp_cliente`(@id_cliente,@cedula);";
                MySqlCommand cmd = new MySqlCommand(sql, c.getConexion().conexionMySQL);
                cmd.Parameters.AddWithValue("@id_cliente", SqlDbType.Int).Value = (object)id_cliente ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@cedula", SqlDbType.Int).Value = (object)cedula ?? DBNull.Value;
                cmd.Prepare();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            return datos;
        }

        private void insert_update(string sql, Clientes cl)
        {
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = (object)cl.cedula ?? DBNull.Value;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = (object)cl.nombre ?? DBNull.Value;
                cmd.Parameters.Add("@apellido1", SqlDbType.VarChar, 50).Value = (object)cl.apellido1 ?? DBNull.Value;
                cmd.Parameters.Add("@apellido2", SqlDbType.VarChar, 50).Value = (object)cl.apellido2 ?? DBNull.Value;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.Write(ex.Message);
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
                cmd.Parameters.AddWithValue("@cedula", SqlDbType.Int).Value = cl.cedula;
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.Int).Value = cl.nombre;
                cmd.Parameters.AddWithValue("@apellido1", SqlDbType.VarChar).Value = cl.apellido1;
                cmd.Parameters.AddWithValue("@apellido2", SqlDbType.VarChar).Value = cl.apellido2;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    c.getConexion().conexionMySQL.Close();
                }
            }
        }

        public void Insert(Clientes cl)
        {
            string sql = "insert into cliente (cedula) "
                    + "values(@cedula);";
            insert_update(sql, cl);
        }

        public void Update(Clientes cl)
        {
            string sql = "exec sp_update_persona @cedula,@nombre,@apellido1,@apellido2;";
            insert_update(sql, cl);
        }

        public void Delete(int id)
        {
            string sql = "delete cliente where id_cliente = @id_cliente;";
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(null, c.getConexion().conexionMSSQL);
                cmd.CommandText = sql;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = id;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.Write(ex.Message);
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
                cmd.Parameters.AddWithValue("@id_cliente", SqlDbType.Int).Value = id;
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    c.getConexion().conexionMySQL.Close();
                }
            }
        }
    }
}
