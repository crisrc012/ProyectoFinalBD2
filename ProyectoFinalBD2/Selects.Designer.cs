﻿using System;

namespace ProyectoFinalBD2
{
    partial class Selects
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvSelects = new System.Windows.Forms.DataGridView();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.cbMotor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelects)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelects
            // 
            this.dgvSelects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelects.Location = new System.Drawing.Point(11, 154);
            this.dgvSelects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSelects.Name = "dgvSelects";
            this.dgvSelects.RowTemplate.Height = 24;
            this.dgvSelects.Size = new System.Drawing.Size(741, 294);
            this.dgvSelects.TabIndex = 0;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(74, 41);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(92, 37);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.Location = new System.Drawing.Point(276, 41);
            this.btnProveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(92, 37);
            this.btnProveedor.TabIndex = 2;
            this.btnProveedor.Text = "Proveedores";
            this.btnProveedor.UseVisualStyleBackColor = true;
            this.btnProveedor.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(434, 41);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(111, 37);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // cbMotor
            // 
            this.cbMotor.FormattingEnabled = true;
            this.cbMotor.Items.AddRange(new object[] {
            "SQL",
            "MYSQL"});
            this.cbMotor.Location = new System.Drawing.Point(276, 129);
            this.cbMotor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMotor.Name = "cbMotor";
            this.cbMotor.Size = new System.Drawing.Size(92, 21);
            this.cbMotor.TabIndex = 4;
            // 
            // Selects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 459);
            this.Controls.Add(this.cbMotor);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnProveedor);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.dgvSelects);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Selects";
            this.Text = "Selects";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelects)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.DataGridView dgvSelects;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedor;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.ComboBox cbMotor;
    }
}