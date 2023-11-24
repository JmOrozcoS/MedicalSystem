namespace Presentation
{
    partial class FormUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsers));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.lbId = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkPassEdit = new System.Windows.Forms.LinkLabel();
            this.txtApass = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCpass = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSname = new System.Windows.Forms.TextBox();
            this.txtSapellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPapellido = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.LbUserName = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(274, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 117;
            this.label2.Text = "Usuario";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdd.IconColor = System.Drawing.Color.White;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 18;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(140, 495);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(108, 23);
            this.btnAdd.TabIndex = 134;
            this.btnAdd.Text = "GUARDAR";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 18;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(27, 495);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.iconButton2.Size = new System.Drawing.Size(109, 23);
            this.iconButton2.TabIndex = 142;
            this.iconButton2.Text = "CANCELAR";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.BackColor = System.Drawing.Color.Transparent;
            this.lbId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbId.ForeColor = System.Drawing.Color.Black;
            this.lbId.Location = new System.Drawing.Point(274, 104);
            this.lbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(58, 17);
            this.lbId.TabIndex = 143;
            this.lbId.Text = "Nombre";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbName.ForeColor = System.Drawing.Color.Black;
            this.lbName.Location = new System.Drawing.Point(274, 136);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(42, 17);
            this.lbName.TabIndex = 145;
            this.lbName.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 37);
            this.label1.TabIndex = 147;
            this.label1.Text = "Mi Perfil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(274, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 149;
            this.label3.Text = "Posicion";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.linkPassEdit);
            this.panel1.Controls.Add(this.txtApass);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtCpass);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSname);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.txtSapellido);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPapellido);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtPname);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Location = new System.Drawing.Point(795, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 643);
            this.panel1.TabIndex = 152;
            this.panel1.Visible = false;
            // 
            // linkPassEdit
            // 
            this.linkPassEdit.AutoSize = true;
            this.linkPassEdit.Location = new System.Drawing.Point(99, 300);
            this.linkPassEdit.Name = "linkPassEdit";
            this.linkPassEdit.Size = new System.Drawing.Size(37, 15);
            this.linkPassEdit.TabIndex = 174;
            this.linkPassEdit.TabStop = true;
            this.linkPassEdit.Text = "Editar";
            this.linkPassEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPassEdit_LinkClicked);
            // 
            // txtApass
            // 
            this.txtApass.BackColor = System.Drawing.Color.White;
            this.txtApass.ForeColor = System.Drawing.Color.Black;
            this.txtApass.Location = new System.Drawing.Point(26, 406);
            this.txtApass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtApass.Name = "txtApass";
            this.txtApass.Size = new System.Drawing.Size(215, 23);
            this.txtApass.TabIndex = 171;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(24, 388);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 15);
            this.label20.TabIndex = 172;
            this.label20.Text = "Contraseña actual";
            // 
            // txtCpass
            // 
            this.txtCpass.BackColor = System.Drawing.Color.White;
            this.txtCpass.ForeColor = System.Drawing.Color.Black;
            this.txtCpass.Location = new System.Drawing.Point(26, 362);
            this.txtCpass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCpass.Name = "txtCpass";
            this.txtCpass.Size = new System.Drawing.Size(215, 23);
            this.txtCpass.TabIndex = 169;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(25, 344);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(122, 15);
            this.label19.TabIndex = 170;
            this.label19.Text = "Confirmar contraseña";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(26, 318);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(215, 23);
            this.txtPass.TabIndex = 167;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(25, 300);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 15);
            this.label18.TabIndex = 168;
            this.label18.Text = "Contraseña";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(26, 274);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(215, 23);
            this.txtEmail.TabIndex = 163;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(24, 256);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 15);
            this.label11.TabIndex = 164;
            this.label11.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(24, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 161;
            this.label5.Text = "Segundo nombre";
            // 
            // txtSname
            // 
            this.txtSname.BackColor = System.Drawing.Color.White;
            this.txtSname.ForeColor = System.Drawing.Color.Black;
            this.txtSname.Location = new System.Drawing.Point(26, 142);
            this.txtSname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSname.Name = "txtSname";
            this.txtSname.Size = new System.Drawing.Size(215, 23);
            this.txtSname.TabIndex = 162;
            // 
            // txtSapellido
            // 
            this.txtSapellido.BackColor = System.Drawing.Color.White;
            this.txtSapellido.ForeColor = System.Drawing.Color.Black;
            this.txtSapellido.Location = new System.Drawing.Point(26, 230);
            this.txtSapellido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSapellido.Name = "txtSapellido";
            this.txtSapellido.Size = new System.Drawing.Size(215, 23);
            this.txtSapellido.TabIndex = 159;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(24, 212);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 160;
            this.label6.Text = "Segundo apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, -3);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 37);
            this.label7.TabIndex = 158;
            this.label7.Text = "Editar Datos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(24, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 154;
            this.label8.Text = "Primer nombre";
            // 
            // txtPapellido
            // 
            this.txtPapellido.BackColor = System.Drawing.Color.White;
            this.txtPapellido.ForeColor = System.Drawing.Color.Black;
            this.txtPapellido.Location = new System.Drawing.Point(26, 186);
            this.txtPapellido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPapellido.Name = "txtPapellido";
            this.txtPapellido.Size = new System.Drawing.Size(215, 23);
            this.txtPapellido.TabIndex = 155;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(24, 168);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 156;
            this.label9.Text = "Primer apellido";
            // 
            // txtPname
            // 
            this.txtPname.BackColor = System.Drawing.Color.White;
            this.txtPname.ForeColor = System.Drawing.Color.Black;
            this.txtPname.Location = new System.Drawing.Point(26, 98);
            this.txtPname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPname.Name = "txtPname";
            this.txtPname.Size = new System.Drawing.Size(215, 23);
            this.txtPname.TabIndex = 157;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(26, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 153;
            this.label10.Text = "Usuario";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.Location = new System.Drawing.Point(26, 54);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(215, 23);
            this.txtUser.TabIndex = 152;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.BackColor = System.Drawing.Color.Transparent;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbUser.ForeColor = System.Drawing.Color.Black;
            this.lbUser.Location = new System.Drawing.Point(274, 89);
            this.lbUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(47, 15);
            this.lbUser.TabIndex = 154;
            this.lbUser.Text = "Usuario";
            // 
            // LbUserName
            // 
            this.LbUserName.AutoSize = true;
            this.LbUserName.BackColor = System.Drawing.Color.Transparent;
            this.LbUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LbUserName.ForeColor = System.Drawing.Color.Black;
            this.LbUserName.Location = new System.Drawing.Point(274, 121);
            this.LbUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbUserName.Name = "LbUserName";
            this.LbUserName.Size = new System.Drawing.Size(51, 15);
            this.LbUserName.TabIndex = 155;
            this.LbUserName.Text = "Nombre";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbEmail.ForeColor = System.Drawing.Color.Black;
            this.lbEmail.Location = new System.Drawing.Point(274, 153);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(36, 15);
            this.lbEmail.TabIndex = 167;
            this.lbEmail.Text = "Email";
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.BackColor = System.Drawing.Color.Transparent;
            this.lbPosition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPosition.ForeColor = System.Drawing.Color.Black;
            this.lbPosition.Location = new System.Drawing.Point(274, 185);
            this.lbPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(52, 15);
            this.lbPosition.TabIndex = 168;
            this.lbPosition.Text = "Posicion";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 18;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(270, 212);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(105, 24);
            this.iconButton1.TabIndex = 170;
            this.iconButton1.Text = "Modificar";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 171;
            this.pictureBox1.TabStop = false;
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 667);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.lbPosition);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.LbUserName);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1216, 700);
            this.Name = "FormUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.FormUsers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label lbId;
        private Label lbName;
        private Label label1;
        private Label label3;
        private Panel panel1;
        private TextBox txtEmail;
        private Label label11;
        private Label label5;
        private TextBox txtSname;
        private TextBox txtSapellido;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtPapellido;
        private Label label9;
        private TextBox txtPname;
        private Label label10;
        private TextBox txtUser;
        private Label lbUser;
        private Label LbUserName;
        private Label lbEmail;
        private Label lbPosition;
        private TextBox txtApass;
        private Label label20;
        private TextBox txtCpass;
        private Label label19;
        private TextBox txtPass;
        private Label label18;
        private FontAwesome.Sharp.IconButton iconButton1;
        private LinkLabel linkPassEdit;
        private PictureBox pictureBox1;
    }
}