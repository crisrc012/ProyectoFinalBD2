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
            string sql = "EXEC sp_factura @id_factura, @id_cliente,@cedula;"; //id_cliente, cedula

            DataTable datos = new DataTable();
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@id_factura", SqlDbType.Int).Value = (object)id_factura ?? DBNull.Value;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = (object)id_cliente ?? DBNull.Value;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = (object)cedula ?? DBNull.Value;
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
    }
}
