namespace Presentation
{
    partial class FormInasistentes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtService = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lbContrato = new System.Windows.Forms.Label();
            this.dgInasistentes = new System.Windows.Forms.DataGridView();
            this.lbId = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.lbCount = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbfiltro = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInasistentes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(637, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 114;
            this.label1.Text = "Servicio";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(142)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1194, 136);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 115;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtService
            // 
            this.txtService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtService.BackColor = System.Drawing.Color.White;
            this.txtService.ForeColor = System.Drawing.Color.Black;
            this.txtService.Location = new System.Drawing.Point(637, 136);
            this.txtService.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(547, 23);
            this.txtService.TabIndex = 113;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.lbTitulo);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.MinimumSize = new System.Drawing.Size(929, 50);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.panel2.Size = new System.Drawing.Size(1303, 55);
            this.panel2.TabIndex = 116;
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(8, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(135, 26);
            this.lbTitulo.TabIndex = 129;
            this.lbTitulo.Text = "INASISTENTES";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Location = new System.Drawing.Point(1881, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 52);
            this.panel1.TabIndex = 130;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.VirusCovid;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(507, -23);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(234, 52);
            this.iconButton1.TabIndex = 105;
            this.iconButton1.Text = "   Laboratorios";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Syringe;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(742, -23);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(232, 52);
            this.iconButton2.TabIndex = 106;
            this.iconButton2.Text = "  Procedimientos";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton3.ForeColor = System.Drawing.Color.White;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.UserDoctor;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 30;
            this.iconButton3.Location = new System.Drawing.Point(975, -23);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(234, 52);
            this.iconButton3.TabIndex = 107;
            this.iconButton3.Text = "     Citas";
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // cmbProgram
            // 
            this.cmbProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.cmbProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProgram.ForeColor = System.Drawing.Color.White;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(8, 84);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(459, 23);
            this.cmbProgram.TabIndex = 142;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // lbContrato
            // 
            this.lbContrato.AutoSize = true;
            this.lbContrato.BackColor = System.Drawing.Color.Transparent;
            this.lbContrato.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbContrato.ForeColor = System.Drawing.Color.Black;
            this.lbContrato.Location = new System.Drawing.Point(8, 66);
            this.lbContrato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbContrato.Name = "lbContrato";
            this.lbContrato.Size = new System.Drawing.Size(126, 15);
            this.lbContrato.TabIndex = 141;
            this.lbContrato.Text = "Seleccione el contrato:";
            // 
            // dgInasistentes
            // 
            this.dgInasistentes.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgInasistentes.AllowUserToAddRows = false;
            this.dgInasistentes.AllowUserToDeleteRows = false;
            this.dgInasistentes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgInasistentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgInasistentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgInasistentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInasistentes.BackgroundColor = System.Drawing.Color.White;
            this.dgInasistentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgInasistentes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(142)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(142)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInasistentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgInasistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgInasistentes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgInasistentes.EnableHeadersVisualStyles = false;
            this.dgInasistentes.GridColor = System.Drawing.SystemColors.Control;
            this.dgInasistentes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgInasistentes.Location = new System.Drawing.Point(9, 216);
            this.dgInasistentes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgInasistentes.MultiSelect = false;
            this.dgInasistentes.Name = "dgInasistentes";
            this.dgInasistentes.ReadOnly = true;
            this.dgInasistentes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInasistentes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgInasistentes.RowHeadersVisible = false;
            this.dgInasistentes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgInasistentes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgInasistentes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgInasistentes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgInasistentes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.dgInasistentes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.dgInasistentes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgInasistentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgInasistentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgInasistentes.Size = new System.Drawing.Size(1284, 324);
            this.dgInasistentes.TabIndex = 151;
            this.dgInasistentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInasistentes_CellContentClick);
            this.dgInasistentes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInasistentes_CellDoubleClick);
            this.dgInasistentes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgInasistentes_CellFormatting);
            // 
            // lbId
            // 
            this.lbId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbId.AutoSize = true;
            this.lbId.BackColor = System.Drawing.Color.Transparent;
            this.lbId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbId.ForeColor = System.Drawing.Color.Black;
            this.lbId.Location = new System.Drawing.Point(636, 65);
            this.lbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(87, 15);
            this.lbId.TabIndex = 155;
            this.lbId.Text = "Identificacion*:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(792, 84);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(303, 23);
            this.txtNombre.TabIndex = 156;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbName.ForeColor = System.Drawing.Color.Black;
            this.lbName.Location = new System.Drawing.Point(792, 65);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(64, 15);
            this.lbName.TabIndex = 157;
            this.lbName.Text = "Nombres*:";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.txtId.Location = new System.Drawing.Point(636, 84);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(148, 23);
            this.txtId.TabIndex = 158;
            // 
            // iconButton4
            // 
            this.iconButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.iconButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(142)))), ((int)(((byte)(128)))));
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromFile;
            this.iconButton4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(142)))), ((int)(((byte)(128)))));
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 25;
            this.iconButton4.Location = new System.Drawing.Point(1194, 79);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.iconButton4.Size = new System.Drawing.Size(99, 28);
            this.iconButton4.TabIndex = 159;
            this.iconButton4.Text = "Exportar";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = true;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // lbCount
            // 
            this.lbCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCount.AutoSize = true;
            this.lbCount.BackColor = System.Drawing.Color.Transparent;
            this.lbCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbCount.ForeColor = System.Drawing.Color.Black;
            this.lbCount.Location = new System.Drawing.Point(1226, 545);
            this.lbCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(0, 15);
            this.lbCount.TabIndex = 161;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.cmbEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbEspecialidad.ForeColor = System.Drawing.Color.White;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(8, 163);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(459, 23);
            this.cmbEspecialidad.TabIndex = 165;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 164;
            this.label2.Text = "Seleccione el contrato:";
            // 
            // cmbfiltro
            // 
            this.cmbfiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbfiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.cmbfiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbfiltro.ForeColor = System.Drawing.Color.White;
            this.cmbfiltro.FormattingEnabled = true;
            this.cmbfiltro.Location = new System.Drawing.Point(637, 175);
            this.cmbfiltro.Name = "cmbfiltro";
            this.cmbfiltro.Size = new System.Drawing.Size(547, 23);
            this.cmbfiltro.TabIndex = 168;
            this.cmbfiltro.SelectedIndexChanged += new System.EventHandler(this.cmbfiltro_SelectedIndexChanged);
            // 
            // FormInasistentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1303, 569);
            this.Controls.Add(this.cmbfiltro);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.iconButton4);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.dgInasistentes);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.lbContrato);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtService);
            this.MinimumSize = new System.Drawing.Size(1150, 272);
            this.Name = "FormInasistentes";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInasistentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox txtService;
        private Panel panel2;
        private Label lbTitulo;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private ComboBox cmbProgram;
        private Label lbContrato;
        private DataGridView dgInasistentes;
        private Label lbId;
        private TextBox txtNombre;
        private Label lbName;
        private TextBox txtId;
        private FontAwesome.Sharp.IconButton iconButton4;
        private Label lbCount;
        private ComboBox cmbEspecialidad;
        private Label label2;
        private ComboBox cmbfiltro;
    }
}