using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Facturas_bd
    {
        private Conexion c;
        bool mysql;

        public Facturas_bd(bool mysql = false)
        {
            this.mysql = mysql;
            c = new Conexion(mysql);
        }

        public DataTable Select(int? id_factura, int? id_cliente = null, int? cedula = null)
        {
            DataTable datos = new DataTable();
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                string sql = 
                    "EXEC sp_factura @id_factura, @id_cliente,@cedula;";
                SqlCommand cmd = 
                    new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@id_factura", SqlDbType.Int).Value = 
                    (object)id_factura ?? DBNull.Value;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = 
                    (object)id_cliente ?? DBNull.Value;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = 
                    (object)cedula ?? DBNull.Value;
                cmd.Prepare();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            else
            {
                c.getConexion().conexionMySQL.Open();
                string sql = 
                    "CALL `proyectofinal`.`sp_factura`(@id_factura, @id_cliente,@cedula);";
                MySqlCommand cmd = 
                    new MySqlCommand(sql, c.getConexion().conexionMySQL);
                cmd.Parameters.AddWithValue("@id_factura", SqlDbType.Int).Value = 
                    (object)id_factura ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@id_cliente", SqlDbType.Int).Value = 
                    (object)id_cliente ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@cedula", SqlDbType.Int).Value = 
                    (object)cedula ?? DBNull.Value;
                cmd.Prepare();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            return datos;
        }
    }
}
