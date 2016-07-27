using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
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
                Logica.Clientes_lg clg = new Logica.Clientes_lg();
                DataTable dt = clg.Select(null, int.Parse(txtCedula.Text));
                if (dt.Rows.Count > 0)
                {
                    txtNombre.Text = dt.Rows[0].Field<string>(2);
                }
                //else
                //{
                //    MessageBox.Show(this,
                //    "No existe nungun cliente con ese numero de cedula",
                //    "Error",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
                //}
            }
            else
            {
                MessageBox.Show("no hay texto del que se pueda buscar","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
