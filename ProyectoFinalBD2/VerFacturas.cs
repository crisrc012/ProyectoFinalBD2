using System;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class VerFacturas : Form
    {
        private int? cedula;
        private bool mysql = false;
        public VerFacturas(int? cedula = null, string cb = null)
        {
            InitializeComponent();
            this.cedula = cedula;
            if (cb == "MySQL")
            {
                mysql = true;
            }
        }

        private void VerFacturas_Load(object sender, EventArgs e)
        {
            Text += " del cliente " + cedula;
            Logica.Factura_lg clg = new Logica.Factura_lg(mysql);
            dGV.DataSource = clg.Select(null,null,cedula);
        }
    }
}
