﻿namespace Registro
{
    partial class Iniciodesesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Iniciodesesion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RolCb = new System.Windows.Forms.ComboBox();
            this.UsuarioTb = new System.Windows.Forms.TextBox();
            this.AccesoBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ContrasenaTb = new System.Windows.Forms.TextBox();
            this.ReiniciarLb = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 30);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(115, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sistema de Registro Médico ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(494, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // RolCb
            // 
            this.RolCb.FormattingEnabled = true;
            this.RolCb.Items.AddRange(new object[] {
            "Admin",
            "Doctor",
            "Recepcionista"});
            this.RolCb.Location = new System.Drawing.Point(142, 249);
            this.RolCb.Margin = new System.Windows.Forms.Padding(4);
            this.RolCb.Name = "RolCb";
            this.RolCb.Size = new System.Drawing.Size(232, 27);
            this.RolCb.TabIndex = 3;
            this.RolCb.SelectedIndexChanged += new System.EventHandler(this.RolCb_SelectedIndexChanged);
            // 
            // UsuarioTb
            // 
            this.UsuarioTb.Location = new System.Drawing.Point(142, 325);
            this.UsuarioTb.Margin = new System.Windows.Forms.Padding(4);
            this.UsuarioTb.Name = "UsuarioTb";
            this.UsuarioTb.Size = new System.Drawing.Size(232, 26);
            this.UsuarioTb.TabIndex = 4;
            // 
            // AccesoBtn
            // 
            this.AccesoBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.AccesoBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccesoBtn.ForeColor = System.Drawing.Color.White;
            this.AccesoBtn.Location = new System.Drawing.Point(201, 465);
            this.AccesoBtn.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.AccesoBtn.Name = "AccesoBtn";
            this.AccesoBtn.Size = new System.Drawing.Size(126, 38);
            this.AccesoBtn.TabIndex = 7;
            this.AccesoBtn.Text = "Acceso";
            this.AccesoBtn.UseVisualStyleBackColor = false;
            this.AccesoBtn.Click += new System.EventHandler(this.AccesoBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(138, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Usuario ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(138, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Contraseña";
            // 
            // ContrasenaTb
            // 
            this.ContrasenaTb.Location = new System.Drawing.Point(142, 398);
            this.ContrasenaTb.Margin = new System.Windows.Forms.Padding(4);
            this.ContrasenaTb.Name = "ContrasenaTb";
            this.ContrasenaTb.Size = new System.Drawing.Size(232, 26);
            this.ContrasenaTb.TabIndex = 12;
            // 
            // ReiniciarLb
            // 
            this.ReiniciarLb.AutoSize = true;
            this.ReiniciarLb.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReiniciarLb.ForeColor = System.Drawing.Color.Black;
            this.ReiniciarLb.Location = new System.Drawing.Point(229, 519);
            this.ReiniciarLb.Name = "ReiniciarLb";
            this.ReiniciarLb.Size = new System.Drawing.Size(70, 19);
            this.ReiniciarLb.TabIndex = 13;
            this.ReiniciarLb.Text = "Reiniciar";
            this.ReiniciarLb.Click += new System.EventHandler(this.label1_Click);
            // 
            // Iniciodesesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 772);
            this.ControlBox = false;
            this.Controls.Add(this.ReiniciarLb);
            this.Controls.Add(this.ContrasenaTb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AccesoBtn);
            this.Controls.Add(this.UsuarioTb);
            this.Controls.Add(this.RolCb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Iniciodesesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox RolCb;
        private System.Windows.Forms.TextBox UsuarioTb;
        private System.Windows.Forms.Button AccesoBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ContrasenaTb;
        private System.Windows.Forms.Label ReiniciarLb;
    }
}

