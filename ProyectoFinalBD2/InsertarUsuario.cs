﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Logica;

namespace ProyectoFinalBD2
{
    public partial class InsertarUsuario : Form
    {
        public InsertarUsuario()
        {
            InitializeComponent();
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios_lg usersbd = null;
                if (cmMotores.SelectedItem == null)
                {
                    MessageBox.Show(this,
                        "Debe de seleccionar un motor de base de datos",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                // ejecutando segun motor
                if (cmMotores.SelectedItem.ToString() == "SQL")
                {
                    usersbd = new Usuarios_lg();
                    Usuarios nuevo = new Usuarios();
                    nuevo.cedula = int.Parse(txtCedula.Text);
                    nuevo.contraseña = txtContrasena.Text;
                    nuevo.id_rol = 1;
                    nuevo.username = txtUsername.Text;
                    usersbd.Insert(nuevo);

                    MessageBox.Show(this,
                        "Usuario insertado correctamente",
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtCedula.Text = "";
                    txtContrasena.Text = "";
                    txtUsername.Text = "";

                }
                else
                {
                    usersbd = new Usuarios_lg(true);
                    Usuarios nuevo = new Usuarios();
                    nuevo.cedula = int.Parse(txtCedula.Text);
                    nuevo.contraseña = txtContrasena.Text;
                    nuevo.id_rol = 1;
                    nuevo.username = txtUsername.Text;
                    usersbd.Insert(nuevo);
                    txtCedula.Text = "";
                    txtContrasena.Text = "";
                    txtUsername.Text = "";

                    MessageBox.Show(this,
                        "Usuario insertado correctamente",
                        "Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception eas )
            {

                MessageBox.Show(eas.Message, "error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }
    }
}
