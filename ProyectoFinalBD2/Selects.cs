using Datos;
using MySql.Data.MySqlClient;
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
            if (cbMotor.SelectedItem.ToString() == "SQL")
            {
                dgvSelects.Rows.Clear();
                string query = "exec dbo.sp_cliente(null,null)";
                SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
                SqlDataReader dtr = cmd.ExecuteReader();
                SqlDataAdapter dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);
                dgvSelects.DataSource = dt;
            }else if(cbMotor.SelectedItem.ToString() == "MySQL")
            {
                dgvSelects.Rows.Clear();
                string query = "exec dbo.sp_cliente(null,null)";
                MySqlCommand mcmd = new MySqlCommand(query, c.getConexion().conexionMySQL);
                MySqlDataReader mdtr = mcmd.ExecuteReader();
                MySqlDataAdapter dta = new MySqlDataAdapter(mcmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);
                dgvSelects.DataSource = dt;
            }else if (cbMotor.SelectedItem==null)
            {
                MessageBox.Show("tiene que escoger un motor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbMotor.SelectedItem.ToString() == "SQL")
            {
                dgvSelects.Rows.Clear();
                string query = "exec dbo.sp_proveedor(null,null)";
                SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
                SqlDataReader dtr = cmd.ExecuteReader();
                SqlDataAdapter dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);
                dgvSelects.DataSource = dt;
            }
            else if (cbMotor.SelectedItem.ToString() == "MySQL")
            {
                dgvSelects.Rows.Clear();
                string query = "exec dbo.sp_proveedor(null,null)";
                MySqlCommand mcmd = new MySqlCommand(query, c.getConexion().conexionMySQL);
                MySqlDataReader mdtr = mcmd.ExecuteReader();
                MySqlDataAdapter dta = new MySqlDataAdapter(mcmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);
                dgvSelects.DataSource = dt;
            }
            else if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show("tiene que escoger un motor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (cbMotor.SelectedItem.ToString() == "SQL")
            {
                dgvSelects.Rows.Clear();
                string query = "exec dbo.sp_usuarios(null,null)";
                SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
                SqlDataReader dtr = cmd.ExecuteReader();
                SqlDataAdapter dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);
                dgvSelects.DataSource = dt;
            }
            else if (cbMotor.SelectedItem.ToString() == "MySQL")
            {
                dgvSelects.Rows.Clear();
                string query = "exec dbo.sp_usuarios(null,null)";
                MySqlCommand mcmd = new MySqlCommand(query, c.getConexion().conexionMySQL);
                MySqlDataReader mdtr = mcmd.ExecuteReader();
                MySqlDataAdapter dta = new MySqlDataAdapter(mcmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);
                dgvSelects.DataSource = dt;
            }
            else if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show("tiene que escoger un motor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


    

