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
            string sql = "EXEC sp_cliente @id_cliente,@cedula;"; //id_cliente, cedula
            
            DataTable datos = new DataTable();
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = (object) id_cliente ?? DBNull.Value;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = (object) cedula ?? DBNull.Value;
                cmd.Prepare();
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

        private void insert_update(string sql, Clientes cl)
        {
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(null, c.getConexion().conexionMSSQL);
                cmd.CommandText = sql;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = cl.cedula;
                cmd.Parameters.Add("@nombre", SqlDbType.Int).Value = cl.nombre;
                cmd.Parameters.Add("@apellido1", SqlDbType.VarChar).Value = cl.apellido1;
                cmd.Parameters.Add("@apellido2", SqlDbType.VarChar).Value = cl.apellido2;
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
                    System.Console.Write(ex.Message);
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
            string sql = "update persona set "
                + "nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2"
                + "where cedula = @cedula;";
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
                cmd.Parameters.AddWithValue("@id_cliente", SqlDbType.Int).Value = id;
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

