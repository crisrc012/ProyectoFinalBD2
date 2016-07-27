using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Proveedores_bd
    {
        private Conexion c;
        bool mysql;

        public Proveedores_bd(bool mysql = false)
        {
            this.mysql = mysql;
            c = new Conexion(mysql);
        }

        public DataTable Select(int? id_proveedor = null, int? cedula = null, int? id_compania = null, string cargo = null)
        {
            string sql = "EXEC sp_proveedor @id_proveedor, @cedula, @id_compania, @cargo;";

            DataTable datos = new DataTable();
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                SqlCommand cmd = new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@id_proveedor", SqlDbType.Int).Value = (object)id_proveedor ?? DBNull.Value;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value = (object)cedula ?? DBNull.Value;
                cmd.Parameters.Add("@id_compania", SqlDbType.Int).Value = (object)id_compania ?? DBNull.Value;
                cmd.Parameters.Add("@cargo", SqlDbType.Int).Value = (object)cargo ?? DBNull.Value;
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
