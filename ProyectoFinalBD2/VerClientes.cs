using System;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class VerClientes : Form
    {
        public VerClientes()
        {
            InitializeComponent();
        }

        private void VerClientes_Load(object sender, EventArgs e)
        {
            Logica.Clientes_lg clg = new Logica.Clientes_lg(false);
            dGV.DataSource = clg.Select();
        }
    }
}
