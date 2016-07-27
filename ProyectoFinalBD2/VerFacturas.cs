using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
