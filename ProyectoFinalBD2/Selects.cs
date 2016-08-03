using Datos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
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
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
                Logica.Clientes_lg clg = new Logica.Clientes_lg();
                dgvSelects.DataSource = clg.Select();
            }
            else if(cbMotor.SelectedItem.ToString() == "MySQL")
            {
                Logica.Clientes_lg clg = new Logica.Clientes_lg(true);
                dgvSelects.DataSource = clg.Select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
                Logica.Proveedores_lg clg = new Logica.Proveedores_lg();
                dgvSelects.DataSource = clg.Select();
            }
            else if (cbMotor.SelectedItem.ToString() == "MySQL")
            {
                Logica.Proveedores_lg clg = new Logica.Proveedores_lg(true);
                dgvSelects.DataSource = clg.Select();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
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
                string query = "exec dbo.sp_usuarios(null,null)";
                MySqlCommand mcmd = new MySqlCommand(query, c.getConexion().conexionMySQL);
                MySqlDataReader mdtr = mcmd.ExecuteReader();
                MySqlDataAdapter dta = new MySqlDataAdapter(mcmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);
                dgvSelects.DataSource = dt;
            }
        }
    }
}


    

