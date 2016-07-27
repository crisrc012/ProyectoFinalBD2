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
    public partial class VerProveedores : Form
    {
        public VerProveedores()
        {
            InitializeComponent();
        }

        private void VerProveedores_Load(object sender, EventArgs e)
        {
            Logica.Proveedores_lg clg = new Logica.Proveedores_lg(false);
            dGV.DataSource = clg.Select();
        }
    }
}
