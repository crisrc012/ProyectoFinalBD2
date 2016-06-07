using System;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void bntObtUsuarios_Click(object sender, EventArgs e)
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
            panel.Controls.Clear();
            // Validando motor
            bool mysql = false;
            if (cmMotores.SelectedItem.ToString() == "MySQL")
            {
                mysql = true;
            }
            panel.Controls.Add(new Tabla(mysql));
            panel.Update();
        }
    }
}
