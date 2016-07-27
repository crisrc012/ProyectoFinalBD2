using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class Selects : Form
    {
        public Conexion c;
        public Usuarios_bd usersbd;
        public Selects()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            string query = "exec dbo.sp_client(null,null)";
            SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
            SqlDataReader dtr = cmd.ExecuteReader();
            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            dgvSelects.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "exec dbo.sp_proveedor(null,null)";
            SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
            SqlDataReader dtr = cmd.ExecuteReader();
            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            dgvSelects.DataSource = dt;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            string query = "exec dbo.sp_usuarios(null,null)";
            SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
            SqlDataReader dtr = cmd.ExecuteReader();
            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            dgvSelects.DataSource = dt;
        }
    }
}
