using Entidades;
using Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class Modificar_Cliente : Form
    {
        private bool mysql;
        public Modificar_Cliente(Clientes cl = null, bool mysql = false)
        {
            InitializeComponent();
            if (cl != null)
            {
                txtCedula.Text = cl.cedula.ToString();
                txtNombre.Text = cl.nombre;
                txtApellido1.Text = cl.apellido1;
                txtApellido2.Text = cl.apellido2;
            }
            if (mysql)
            {
                cbMotor.SelectedItem = "MySQL";
            }
            this.mysql = mysql;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Clientes c = new Clientes();
            c.cedula = int.Parse(txtCedula.Text);
            c.nombre = txtNombre.Text;
            c.apellido1 = txtApellido1.Text;
            c.apellido2 = txtApellido2.Text;
            Clientes_lg clg = new Clientes_lg();
            clg.Update(c);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text != string.Empty)
            {
                Clientes_lg clg = new Clientes_lg(mysql);
                DataTable dt = clg.Select(null, int.Parse(txtCedula.Text));
                if (dt.Rows.Count > 0)
                {
                    txtNombre.Text = dt.Rows[0].Field<string>(2);
                    txtApellido1.Text = dt.Rows[0].Field<string>(3);
                    txtApellido2.Text = dt.Rows[0].Field<string>(4);
                }
                else
                {
                    MessageBox.Show(this,
                    "No existe ningún cliente con ese número de cédula.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this,
                    "Cédula inválida.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Modificar_Cliente_Load(object sender, EventArgs e)
        {
            cbMotor.SelectedIndex = 0;
        }

        private void cbMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
                mysql = false;
            }
            else
            {
                mysql = true;
            }
        }
    }
}
