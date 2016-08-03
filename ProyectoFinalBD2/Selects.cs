using System;
using System.Windows.Forms;
using Logica;
using Entidades;

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
            gbClientes.Visible = true;
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
            gbClientes.Visible = false;
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
            gbClientes.Visible = false;
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

        private void btnClModificar_Click(object sender, EventArgs e)
        {
            if (dgvSelects.SelectedRows.Count != 1)
            {
                MessageBox.Show(this, "Debe de seleccionar únicamente un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Clientes cl = new Clientes();
            cl.id_cliente = 
                int.Parse(dgvSelects.Rows[dgvSelects.SelectedRows[0].Index].Cells[0].Value.ToString());
            cl.cedula = 
                int.Parse(dgvSelects.Rows[dgvSelects.SelectedRows[0].Index].Cells[1].Value.ToString());
            cl.nombre = 
                dgvSelects.Rows[dgvSelects.SelectedRows[0].Index].Cells[2].Value.ToString();
            cl.apellido1 = 
                dgvSelects.Rows[dgvSelects.SelectedRows[0].Index].Cells[3].Value.ToString();
            cl.apellido2 = 
                dgvSelects.Rows[dgvSelects.SelectedRows[0].Index].Cells[4].Value.ToString();
            Modificar_Cliente mdf = new Modificar_Cliente(cl,cbMotor.SelectedItem.ToString());
            mdf.MdiParent = MdiParent;
            mdf.Show();
        }

        private void btnClFacturas_Click(object sender, EventArgs e)
        {
            if (dgvSelects.SelectedRows.Count != 1)
            {
                MessageBox.Show(this, 
                    "Debe de seleccionar únicamente un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VerFacturas mdf = 
                new VerFacturas(int.Parse(dgvSelects.Rows[dgvSelects.SelectedRows[0].Index].Cells[1].Value.ToString()), 
                cbMotor.SelectedItem.ToString());
            mdf.MdiParent = MdiParent;
            mdf.Show();
        }
    }
}


    

