using System;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class VerFacturas : Form
    {
        public VerFacturas()
        {
            InitializeComponent();
        }

        private void VerFacturas_Load(object sender, EventArgs e)
        {
            Logica.Factura_lg clg = new Logica.Factura_lg(false);
            dGV.DataSource = clg.Select();
        }
    }
}
