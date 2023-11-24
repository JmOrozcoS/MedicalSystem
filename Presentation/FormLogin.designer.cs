namespace Presentation
{
    partial class FormLogin
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
            this.lbcontraseña = new System.Windows.Forms.Label();
            this.txtcontrasena = new System.Windows.Forms.TextBox();
            this.lnNameApp = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.LabelInformation = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.Errorlb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbcontraseña
            // 
            this.lbcontraseña.AutoSize = true;
            this.lbcontraseña.BackColor = System.Drawing.Color.Transparent;
            this.lbcontraseña.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbcontraseña.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbcontraseña.Location = new System.Drawing.Point(32, 116);
            this.lbcontraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbcontraseña.Name = "lbcontraseña";
            this.lbcontraseña.Size = new System.Drawing.Size(69, 15);
            this.lbcontraseña.TabIndex = 14;
            this.lbcontraseña.Text = "Contraseña";
            // 
            // txtcontrasena
            // 
            this.txtcontrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.txtcontrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcontrasena.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtcontrasena.ForeColor = System.Drawing.Color.White;
            this.txtcontrasena.Location = new System.Drawing.Point(119, 117);
            this.txtcontrasena.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtcontrasena.Name = "txtcontrasena";
            this.txtcontrasena.PasswordChar = '*';
            this.txtcontrasena.Size = new System.Drawing.Size(215, 14);
            this.txtcontrasena.TabIndex = 13;
            this.txtcontrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcontrasena_KeyPress);
            // 
            // lnNameApp
            // 
            this.lnNameApp.AutoSize = true;
            this.lnNameApp.BackColor = System.Drawing.Color.Transparent;
            this.lnNameApp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lnNameApp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lnNameApp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lnNameApp.Location = new System.Drawing.Point(32, 46);
            this.lnNameApp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnNameApp.Name = "lnNameApp";
            this.lnNameApp.Size = new System.Drawing.Size(72, 19);
            this.lnNameApp.TabIndex = 17;
            this.lnNameApp.Text = "VS v1.04";
            this.lnNameApp.Click += new System.EventHandler(this.lnNameApp_Click);
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.btLogin.FlatAppearance.BorderSize = 0;
            this.btLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.btLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(76)))), ((int)(((byte)(84)))));
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btLogin.Location = new System.Drawing.Point(35, 193);
            this.btLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(128, 25);
            this.btLogin.TabIndex = 21;
            this.btLogin.Text = "INICIAR SESIÓN";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(69)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(76)))), ((int)(((byte)(84)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.Location = new System.Drawing.Point(206, 193);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 25);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // LabelInformation
            // 
            this.LabelInformation.AutoSize = true;
            this.LabelInformation.BackColor = System.Drawing.Color.Transparent;
            this.LabelInformation.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelInformation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelInformation.Location = new System.Drawing.Point(14, 5);
            this.LabelInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelInformation.Name = "LabelInformation";
            this.LabelInformation.Size = new System.Drawing.Size(91, 15);
            this.LabelInformation.TabIndex = 23;
            this.LabelInformation.Text = "Inicio de Sesión";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnClose.Location = new System.Drawing.Point(342, 9);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(14, 16);
            this.BtnClose.TabIndex = 24;
            this.BtnClose.Text = "x";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.BackColor = System.Drawing.Color.Transparent;
            this.lbFecha.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbFecha.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbFecha.Location = new System.Drawing.Point(33, 182);
            this.lbFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(0, 15);
            this.lbFecha.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(32, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Usuario";
            // 
            // txtuser
            // 
            this.txtuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuser.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtuser.ForeColor = System.Drawing.Color.White;
            this.txtuser.Location = new System.Drawing.Point(119, 97);
            this.txtuser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(215, 14);
            this.txtuser.TabIndex = 26;
            // 
            // Errorlb
            // 
            this.Errorlb.AutoSize = true;
            this.Errorlb.BackColor = System.Drawing.Color.Transparent;
            this.Errorlb.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Errorlb.ForeColor = System.Drawing.Color.RosyBrown;
            this.Errorlb.Location = new System.Drawing.Point(119, 149);
            this.Errorlb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Errorlb.Name = "Errorlb";
            this.Errorlb.Size = new System.Drawing.Size(32, 15);
            this.Errorlb.TabIndex = 28;
            this.Errorlb.Text = "Error";
            this.Errorlb.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(369, 261);
            this.ControlBox = false;
            this.Controls.Add(this.Errorlb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LabelInformation);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.lnNameApp);
            this.Controls.Add(this.lbcontraseña);
            this.Controls.Add(this.txtcontrasena);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbcontraseña;
        private System.Windows.Forms.TextBox txtcontrasena;
        private System.Windows.Forms.Label lnNameApp;
        internal System.Windows.Forms.Button btLogin;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Label LabelInformation;
        internal System.Windows.Forms.Label BtnClose;
        private System.Windows.Forms.Label lbFecha;
        private Label label3;
        private TextBox txtuser;
        private Label Errorlb;
    }
}