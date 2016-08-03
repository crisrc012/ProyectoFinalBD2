using Entidades;
using Logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class Modificar_Cliente : Form
    {
        public Modificar_Cliente(Clientes cl = null)
        {
            InitializeComponent();
            if (cl != null)
            {
                txtCedula.Text = cl.cedula.ToString();
                txtNombre.Text = cl.nombre;
                txtApellido1.Text = cl.apellido1;
                txtApellido2.Text = cl.apellido2;
            }
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
                Clientes_lg clg = new Clientes_lg();
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
                MessageBox.Show("Cédula inválida.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
