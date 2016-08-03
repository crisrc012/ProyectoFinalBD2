using System;
using System.Windows.Forms;
using Logica;

namespace ProyectoFinalBD2
{
    public partial class Selects : Form
    {
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
            Logica.Clientes_lg clg = null;
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
                clg = new Clientes_lg();
            }
            else if(cbMotor.SelectedItem.ToString() == "MySQL")
            {
                clg = new Clientes_lg(true);
            }
            dgvSelects.DataSource = clg.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Logica.Proveedores_lg clg = null;
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
                clg = new Proveedores_lg();
            }
            else if (cbMotor.SelectedItem.ToString() == "MySQL")
            {
                clg = new Proveedores_lg(true);
            }
            dgvSelects.DataSource = clg.Select();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Logica.Usuarios_lg clg = null;
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
                clg = new Usuarios_lg();
            }
            else if (cbMotor.SelectedItem.ToString() == "MySQL")
            {
                clg = new Usuarios_lg(true);
            }
            dgvSelects.DataSource = clg.Select();
        }
    }
}


    

