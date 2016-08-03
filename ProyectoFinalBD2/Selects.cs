using System;
using System.Windows.Forms;
using Logica;

namespace ProyectoFinalBD2
{
    public partial class Selects : Form
    {
        public Selects(string entidad = null)
        {
            InitializeComponent();
            if (entidad != null)
            {
                cbMotor.SelectedIndex = 0;
                switch (entidad)
                {
                    case "Clientes":
                        mostrarClientes();
                        break;
                    case "Proveedores":
                        mostrarProveedores();
                        break;
                    case "Usuarios":
                        mostrarUsuarios();
                        break;
                    default:
                        break;
                }
            }
        }

        private void mostrarClientes()
        {
            Text = "Mostrando Clientes";
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Clientes_lg clg = null;
            if (cbMotor.SelectedItem.ToString() == "SQL Server")
            {
                clg = new Clientes_lg();
            }
            else if (cbMotor.SelectedItem.ToString() == "MySQL")
            {
                clg = new Clientes_lg(true);
            }
            dgvSelects.DataSource = clg.Select();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            mostrarClientes();
        }

        private void mostrarProveedores()
        { 
            Text = "Mostrando Proveedores";
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Proveedores_lg clg = null;
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

        private void button2_Click(object sender, EventArgs e) //btnProveedores
        {
            mostrarProveedores();
        }

        private void mostrarUsuarios()
        {
            Text = "Mostrando Usuarios";
            if (cbMotor.SelectedItem == null)
            {
                MessageBox.Show(this, "Seleccione un motor de base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Usuarios_lg clg = null;
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }
    }
}


    

