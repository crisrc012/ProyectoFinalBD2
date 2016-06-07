using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace ProyectoFinalBD2
{
    public partial class Tabla : UserControl
    {
        public Tabla()
        {
            InitializeComponent();
        }

        private void Tabla_Load(object sender, EventArgs e)
        {
            Usuarios_lg ulg = new Usuarios_lg();
            dGV.DataSource = ulg.Select();
        }
    }
}
