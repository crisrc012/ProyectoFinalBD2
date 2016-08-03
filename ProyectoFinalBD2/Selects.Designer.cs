using System;

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
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.cbMotor = new System.Windows.Forms.ComboBox();
            this.lblMotor = new System.Windows.Forms.Label();
            this.gbClientes = new System.Windows.Forms.GroupBox();
            this.btnClFacturas = new System.Windows.Forms.Button();
            this.btnClModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelects)).BeginInit();
            this.gbClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSelects
            // 
            this.dgvSelects.AllowUserToAddRows = false;
            this.dgvSelects.AllowUserToDeleteRows = false;
            this.dgvSelects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelects.Location = new System.Drawing.Point(11, 80);
            this.dgvSelects.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSelects.MultiSelect = false;
            this.dgvSelects.Name = "dgvSelects";
            this.dgvSelects.ReadOnly = true;
            this.dgvSelects.RowTemplate.Height = 24;
            this.dgvSelects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelects.ShowEditingIcon = false;
            this.dgvSelects.Size = new System.Drawing.Size(683, 368);
            this.dgvSelects.TabIndex = 0;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(15, 39);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(92, 37);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.Location = new System.Drawing.Point(111, 39);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(2);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(92, 37);
            this.btnProveedores.TabIndex = 2;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(207, 39);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(111, 37);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // cbMotor
            // 
            this.cbMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotor.FormattingEnabled = true;
            this.cbMotor.Items.AddRange(new object[] {
            "SQL Server",
            "MySQL"});
            this.cbMotor.Location = new System.Drawing.Point(139, 6);
            this.cbMotor.Margin = new System.Windows.Forms.Padding(2);
            this.cbMotor.Name = "cbMotor";
            this.cbMotor.Size = new System.Drawing.Size(179, 21);
            this.cbMotor.TabIndex = 4;
            // 
            // lblMotor
            // 
            this.lblMotor.AutoSize = true;
            this.lblMotor.Location = new System.Drawing.Point(12, 9);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(122, 13);
            this.lblMotor.TabIndex = 5;
            this.lblMotor.Text = "Motor de base de datos:";
            // 
            // gbClientes
            // 
            this.gbClientes.Controls.Add(this.btnClModificar);
            this.gbClientes.Controls.Add(this.btnClFacturas);
            this.gbClientes.Location = new System.Drawing.Point(323, 6);
            this.gbClientes.Name = "gbClientes";
            this.gbClientes.Size = new System.Drawing.Size(370, 69);
            this.gbClientes.TabIndex = 6;
            this.gbClientes.TabStop = false;
            this.gbClientes.Text = "Opciones Cliente";
            // 
            // btnClFacturas
            // 
            this.btnClFacturas.Location = new System.Drawing.Point(77, 33);
            this.btnClFacturas.Name = "btnClFacturas";
            this.btnClFacturas.Size = new System.Drawing.Size(75, 23);
            this.btnClFacturas.TabIndex = 0;
            this.btnClFacturas.Text = "Ver Facturas";
            this.btnClFacturas.UseVisualStyleBackColor = true;
            // 
            // btnClModificar
            // 
            this.btnClModificar.Location = new System.Drawing.Point(158, 33);
            this.btnClModificar.Name = "btnClModificar";
            this.btnClModificar.Size = new System.Drawing.Size(75, 23);
            this.btnClModificar.TabIndex = 1;
            this.btnClModificar.Text = "Modificar";
            this.btnClModificar.UseVisualStyleBackColor = true;
            // 
            // Selects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 459);
            this.Controls.Add(this.gbClientes);
            this.Controls.Add(this.lblMotor);
            this.Controls.Add(this.cbMotor);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.dgvSelects);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Selects";
            this.Text = "Selects";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelects)).EndInit();
            this.gbClientes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.DataGridView dgvSelects;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.ComboBox cbMotor;
        private System.Windows.Forms.Label lblMotor;
        private System.Windows.Forms.GroupBox gbClientes;
        private System.Windows.Forms.Button btnClModificar;
        private System.Windows.Forms.Button btnClFacturas;
    }
}