namespace ProyectoFinalBD2
{
    partial class Login
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
            this.cmMotores = new System.Windows.Forms.ComboBox();
            this.lblMotor = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.bntObtUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmMotores
            // 
            this.cmMotores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmMotores.FormattingEnabled = true;
            this.cmMotores.Items.AddRange(new object[] {
            "MySQL",
            "MSSQL"});
            this.cmMotores.Location = new System.Drawing.Point(52, 228);
            this.cmMotores.Name = "cmMotores";
            this.cmMotores.Size = new System.Drawing.Size(220, 21);
            this.cmMotores.TabIndex = 0;
            // 
            // lblMotor
            // 
            this.lblMotor.AutoSize = true;
            this.lblMotor.Location = new System.Drawing.Point(12, 231);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(34, 13);
            this.lblMotor.TabIndex = 1;
            this.lblMotor.Text = "Motor";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(15, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(257, 210);
            this.panel.TabIndex = 2;
            // 
            // bntObtUsuarios
            // 
            this.bntObtUsuarios.Location = new System.Drawing.Point(15, 263);
            this.bntObtUsuarios.Name = "bntObtUsuarios";
            this.bntObtUsuarios.Size = new System.Drawing.Size(257, 23);
            this.bntObtUsuarios.TabIndex = 3;
            this.bntObtUsuarios.Text = "Obtener Usuarios";
            this.bntObtUsuarios.UseVisualStyleBackColor = true;
            this.bntObtUsuarios.Click += new System.EventHandler(this.bntObtUsuarios_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 298);
            this.Controls.Add(this.bntObtUsuarios);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lblMotor);
            this.Controls.Add(this.cmMotores);
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmMotores;
        private System.Windows.Forms.Label lblMotor;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button bntObtUsuarios;
    }
}

