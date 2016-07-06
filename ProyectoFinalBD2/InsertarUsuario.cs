using Datos;
using Entidades;
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
using MySql.Data.MySqlClient;

namespace ProyectoFinalBD2
{
    public partial class InsertarUsuario : Form
    {
        public Conexion c;
        public Usuarios_bd usersbd;
        public InsertarUsuario()
        {
            InitializeComponent();
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (cmMotores.SelectedItem == null)
            {
                MessageBox.Show(this,
                    "Debe de seleccionar un motor de base de datos",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            txtCedula.Text = "";
            // ejecutando segun motor
            if (cmMotores.SelectedItem.ToString() == "SQL")
            {
                string query = "Select * from Persona where Cedula='" + txtCedula + "'";
                SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
                SqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    Usuarios nuevo = new Usuarios();
                    nuevo.cedula = Int32.Parse(txtCedula.Text);
                    nuevo.contraseña = txtContrasena.Text;
                    nuevo.id_rol = 1;
                    nuevo.id_usuarios = Int32.Parse(txtIdUsuario.Text);
                    nuevo.username = txtUsername.Text;
                    usersbd.Insert(nuevo);
                }else
                {
                    MessageBox.Show(this,
                    "No existe nunguna persona con ese numero de cedula",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
        

            } else
            {
                string query = "Select * from Persona where Cedula='" + txtCedula + "'";
                MySqlCommand cmd = new MySqlCommand(query,c.getConexion().conexionMySQL);
                MySqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    Usuarios nuevo = new Usuarios();
                    nuevo.cedula = Int32.Parse(txtCedula.Text);
                    nuevo.contraseña = txtContrasena.Text;
                    nuevo.id_rol = 1;
                    nuevo.id_usuarios = Int32.Parse(txtIdUsuario.Text);
                    nuevo.username = txtUsername.Text;
                    usersbd.Insert(nuevo);
                }
                else
                {
                    MessageBox.Show(this,
                    "No existe nunguna persona con ese numero de cedula",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
