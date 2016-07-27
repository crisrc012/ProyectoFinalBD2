using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class Modificar_Cliente : Form
    {
        public Modificar_Cliente()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != "")
            {
                string query = "Select * from cliente where Cedula='" + txtCedula + "'";
                SqlCommand cmd = new SqlCommand(query, c.getConexion().conexionMSSQL);
                SqlDataReader dtr = cmd.ExecuteReader();
                if (dtr.HasRows)
                {
                    Usuarios nuevo = new Usuarios();
                    nuevo.cedula = Int32.Parse(txtCedula.Text);
                    nuevo.contraseña = txtContrasena.Text;
                    nuevo.id_rol = 1;
                    nuevo.username = txtUsername.Text;
                    usersbd.Insert(nuevo);
                }
                else
                {
                    MessageBox.Show(this,
                    "No existe nungun cliente con ese numero de cedula",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("no hay texto del que se pueda buscar","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
