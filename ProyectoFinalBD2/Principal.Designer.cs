namespace ProyectoFinalBD2
{
    partial class Principal
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
            this.titulo = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cliente = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.verClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_factura = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_proveedor = new System.Windows.Forms.ToolStripMenuItem();
            this.lblintegrantes = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.insertarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(233, 91);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(330, 25);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "Proyecto Final Bases de Datos II ";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_usuarios,
            this.menu_cliente,
            this.menu_factura,
            this.menu_proveedor});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(801, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menu";
            // 
            // menu_usuarios
            // 
            this.menu_usuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarUsuarioToolStripMenuItem});
            this.menu_usuarios.Name = "menu_usuarios";
            this.menu_usuarios.Size = new System.Drawing.Size(64, 20);
            this.menu_usuarios.Text = "Usuarios";
            // 
            // menu_cliente
            // 
            this.menu_cliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarCliente,
            this.verClientes});
            this.menu_cliente.Name = "menu_cliente";
            this.menu_cliente.Size = new System.Drawing.Size(61, 20);
            this.menu_cliente.Text = "Clientes";
            // 
            // modificarCliente
            // 
            this.modificarCliente.Name = "modificarCliente";
            this.modificarCliente.Size = new System.Drawing.Size(165, 22);
            this.modificarCliente.Text = "Modificar Cliente";
            this.modificarCliente.Click += new System.EventHandler(this.modificarCliente_Click);
            // 
            // verClientes
            // 
            this.verClientes.Name = "verClientes";
            this.verClientes.Size = new System.Drawing.Size(165, 22);
            this.verClientes.Text = "Ver Clientes";
            // 
            // menu_factura
            // 
            this.menu_factura.Name = "menu_factura";
            this.menu_factura.Size = new System.Drawing.Size(58, 20);
            this.menu_factura.Text = "Factura";
            // 
            // menu_proveedor
            // 
            this.menu_proveedor.Name = "menu_proveedor";
            this.menu_proveedor.Size = new System.Drawing.Size(84, 20);
            this.menu_proveedor.Text = "Proveedores";
            // 
            // lblintegrantes
            // 
            this.lblintegrantes.AutoSize = true;
            this.lblintegrantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblintegrantes.Location = new System.Drawing.Point(344, 137);
            this.lblintegrantes.Name = "lblintegrantes";
            this.lblintegrantes.Size = new System.Drawing.Size(95, 20);
            this.lblintegrantes.TabIndex = 2;
            this.lblintegrantes.Text = "Integrantes:";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName1.Location = new System.Drawing.Point(303, 167);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(165, 20);
            this.lblName1.TabIndex = 3;
            this.lblName1.Text = "Paola Aguirre Méndez";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.Location = new System.Drawing.Point(303, 203);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(180, 20);
            this.lblName2.TabIndex = 4;
            this.lblName2.Text = "Arturo Fallas Fernández";
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName3.Location = new System.Drawing.Point(303, 240);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(172, 20);
            this.lblName3.TabIndex = 5;
            this.lblName3.Text = "Cristopher Robles Ríos";
            // 
            // insertarUsuarioToolStripMenuItem
            // 
            this.insertarUsuarioToolStripMenuItem.Name = "insertarUsuarioToolStripMenuItem";
            this.insertarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.insertarUsuarioToolStripMenuItem.Text = "Insertar Usuario";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 359);
            this.Controls.Add(this.lblName3);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblName1);
            this.Controls.Add(this.lblintegrantes);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menu_usuarios;
        private System.Windows.Forms.ToolStripMenuItem menu_cliente;
        private System.Windows.Forms.ToolStripMenuItem menu_factura;
        private System.Windows.Forms.ToolStripMenuItem menu_proveedor;
        private System.Windows.Forms.ToolStripMenuItem modificarCliente;
        private System.Windows.Forms.ToolStripMenuItem verClientes;
        private System.Windows.Forms.ToolStripMenuItem insertarUsuarioToolStripMenuItem;
        private System.Windows.Forms.Label lblintegrantes;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName3;
    }
}