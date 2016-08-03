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
            DataTable datos = new DataTable();
            if (!mysql)
            {
                c.getConexion().conexionMSSQL.Open();
                string sql = 
                    "EXEC sp_proveedor @id_proveedor, @cedula, @id_compania, @cargo;";
                SqlCommand cmd = 
                    new SqlCommand(sql, c.getConexion().conexionMSSQL);
                cmd.Parameters.Add("@id_proveedor", SqlDbType.Int).Value =
                    (object)id_proveedor ?? DBNull.Value;
                cmd.Parameters.Add("@cedula", SqlDbType.Int).Value =
                    (object)cedula ?? DBNull.Value;
                cmd.Parameters.Add("@id_compania", SqlDbType.Int).Value =
                    (object)id_compania ?? DBNull.Value;
                cmd.Parameters.Add("@cargo", SqlDbType.Int).Value =
                    (object)cargo ?? DBNull.Value;
                cmd.Prepare();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            else
            {
                c.getConexion().conexionMySQL.Open();
                string sql = 
                    "CALL `proyectofinal`.`sp_proveedor`(@id_proveedor, @cedula, @id_compania, @cargo)";
                MySqlCommand cmd = 
                    new MySqlCommand(sql, c.getConexion().conexionMySQL);
                cmd.Parameters.AddWithValue("@id_proveedor", SqlDbType.Int).Value =
                    (object)id_proveedor ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@cedula", SqlDbType.Int).Value =
                    (object)cedula ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@id_compania", SqlDbType.Int).Value =
                    (object)id_compania ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@cargo", SqlDbType.Int).Value =
                    (object)cargo ?? DBNull.Value;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            return datos;
        }
    }
}
