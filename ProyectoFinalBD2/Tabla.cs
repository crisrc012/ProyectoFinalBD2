using System;
using System.Windows.Forms;
using Logica;

namespace ProyectoFinalBD2
{
    public partial class Tabla : UserControl
    {
        private bool mysql;

        public Tabla(bool mysql = false)
        {
            InitializeComponent();
            this.mysql = mysql;
        }

        private void Tabla_Load(object sender, EventArgs e)
        {
            Usuarios_lg ulg = new Usuarios_lg(mysql);
            dGV.DataSource = ulg.Select();
        }
    }
}
