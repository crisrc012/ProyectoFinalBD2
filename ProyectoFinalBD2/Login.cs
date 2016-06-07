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
            panel.Controls.Clear();
            panel.Controls.Add(new Tabla());
            panel.Update();
        }
    }
}
