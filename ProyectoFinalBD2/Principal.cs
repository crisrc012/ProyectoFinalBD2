﻿using System;
using System.Windows.Forms;

namespace ProyectoFinalBD2
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;

        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void modificarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Modificar_Cliente mdf = new Modificar_Cliente();
            mdf.MdiParent = this; 
            mdf.Show();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selects mdf = new Selects("Clientes");
            mdf.MdiParent = this;
            mdf.Show();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selects mdf = new Selects("Usuarios");
            mdf.MdiParent = this;
            mdf.Show();
        }

        private void verProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selects mdf = new Selects("Proveedores");
            mdf.MdiParent = this;
            mdf.Show();
        }

        private void verFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Microsoft.VisualBasic.Interaction.InputBox("Digite la cédula del cliente:", "Ver Facturas");
                if (text == string.Empty)
                {
                    MessageBox.Show(this,"La cédula no puede estar vacía.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                int cedula = int.Parse(text);
                VerFacturas mdf = new VerFacturas(cedula);
                mdf.MdiParent = this;
                mdf.Show();
            }
            catch
            {
                MessageBox.Show(this, "La cédula no puede contener letras.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        private void insertarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertarUsuario mdf = new InsertarUsuario();
            mdf.MdiParent = this; 
            mdf.Show();
        }
    }
}
