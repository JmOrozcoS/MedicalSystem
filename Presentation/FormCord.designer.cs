
namespace Presentation
{
    partial class FormCord
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
            this.txtMed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeFechaini = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.dgCola = new System.Windows.Forms.DataGridView();
            this.cmbSede = new System.Windows.Forms.ComboBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.cmbFechas = new System.Windows.Forms.ComboBox();
            this.rbtnBuscarFecha = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rbtnBuscarM = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMed
            // 
            this.txtMed.Location = new System.Drawing.Point(4, 28);
            this.txtMed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMed.Name = "txtMed";
            this.txtMed.Size = new System.Drawing.Size(123, 23);
            this.txtMed.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(4, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 104;
            this.label5.Text = "Seleccione la Sede:";
            // 
            // dateTimeFechaini
            // 
            this.dateTimeFechaini.CustomFormat = "YYYY/MM/DD";
            this.dateTimeFechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechaini.Location = new System.Drawing.Point(132, 28);
            this.dateTimeFechaini.Name = "dateTimeFechaini";
            this.dateTimeFechaini.Size = new System.Drawing.Size(97, 23);
            this.dateTimeFechaini.TabIndex = 105;
            this.dateTimeFechaini.Value = new System.DateTime(2022, 7, 6, 14, 1, 42, 0);
            // 
            // dateTimeFechaFin
            // 
            this.dateTimeFechaFin.CustomFormat = "YYYY/MM/DD";
            this.dateTimeFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechaFin.Location = new System.Drawing.Point(235, 28);
            this.dateTimeFechaFin.Name = "dateTimeFechaFin";
            this.dateTimeFechaFin.Size = new System.Drawing.Size(97, 23);
            this.dateTimeFechaFin.TabIndex = 106;
            this.dateTimeFechaFin.Value = new System.DateTime(2022, 7, 6, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(234, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 15);
            this.label6.TabIndex = 108;
            this.label6.Text = "Seleccione el contrato:";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.MinimumSize = new System.Drawing.Size(929, 50);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.panel2.Size = new System.Drawing.Size(1084, 55);
            this.panel2.TabIndex = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 26);
            this.label7.TabIndex = 129;
            this.label7.Text = "REPORTE DE ATENCIONES";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Location = new System.Drawing.Point(1659, 0);
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
            // dgCola
            // 
            this.dgCola.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgCola.AllowUserToAddRows = false;
            this.dgCola.AllowUserToDeleteRows = false;
            this.dgCola.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgCola.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCola.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCola.BackgroundColor = System.Drawing.Color.White;
            this.dgCola.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCola.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCola.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgCola.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCola.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgCola.EnableHeadersVisualStyles = false;
            this.dgCola.GridColor = System.Drawing.SystemColors.Control;
            this.dgCola.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgCola.Location = new System.Drawing.Point(12, 379);
            this.dgCola.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgCola.Name = "dgCola";
            this.dgCola.ReadOnly = true;
            this.dgCola.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCola.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgCola.RowHeadersVisible = false;
            this.dgCola.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgCola.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgCola.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgCola.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgCola.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.dgCola.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.dgCola.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgCola.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCola.Size = new System.Drawing.Size(1060, 329);
            this.dgCola.TabIndex = 116;
            this.dgCola.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgCola_CellFormatting);
            // 
            // cmbSede
            // 
            this.cmbSede.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.cmbSede.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSede.ForeColor = System.Drawing.Color.White;
            this.cmbSede.FormattingEnabled = true;
            this.cmbSede.Location = new System.Drawing.Point(3, 28);
            this.cmbSede.Name = "cmbSede";
            this.cmbSede.Size = new System.Drawing.Size(226, 23);
            this.cmbSede.TabIndex = 143;
            this.cmbSede.SelectedIndexChanged += new System.EventHandler(this.cmbSede_SelectedIndexChanged_1);
            // 
            // cmbProgram
            // 
            this.cmbProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.cmbProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProgram.ForeColor = System.Drawing.Color.White;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(234, 28);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(226, 23);
            this.cmbProgram.TabIndex = 144;
            // 
            // cmbFechas
            // 
            this.cmbFechas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(87)))));
            this.cmbFechas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFechas.ForeColor = System.Drawing.Color.White;
            this.cmbFechas.FormattingEnabled = true;
            this.cmbFechas.Location = new System.Drawing.Point(3, 28);
            this.cmbFechas.Name = "cmbFechas";
            this.cmbFechas.Size = new System.Drawing.Size(118, 23);
            this.cmbFechas.TabIndex = 147;
            // 
            // rbtnBuscarFecha
            // 
            this.rbtnBuscarFecha.AutoSize = true;
            this.rbtnBuscarFecha.Location = new System.Drawing.Point(3, 3);
            this.rbtnBuscarFecha.Name = "rbtnBuscarFecha";
            this.rbtnBuscarFecha.Size = new System.Drawing.Size(118, 19);
            this.rbtnBuscarFecha.TabIndex = 148;
            this.rbtnBuscarFecha.TabStop = true;
            this.rbtnBuscarFecha.Text = "Buscar por fechas";
            this.rbtnBuscarFecha.UseVisualStyleBackColor = true;
            this.rbtnBuscarFecha.CheckedChanged += new System.EventHandler(this.rbtnBuscarFecha_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(483, 70);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rbtnBuscarM);
            this.splitContainer1.Panel1.Controls.Add(this.txtMed);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rbtnBuscarFecha);
            this.splitContainer1.Panel2.Controls.Add(this.cmbFechas);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimeFechaini);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimeFechaFin);
            this.splitContainer1.Size = new System.Drawing.Size(526, 88);
            this.splitContainer1.SplitterDistance = 149;
            this.splitContainer1.TabIndex = 149;
            // 
            // rbtnBuscarM
            // 
            this.rbtnBuscarM.AutoSize = true;
            this.rbtnBuscarM.Location = new System.Drawing.Point(3, 3);
            this.rbtnBuscarM.Name = "rbtnBuscarM";
            this.rbtnBuscarM.Size = new System.Drawing.Size(124, 19);
            this.rbtnBuscarM.TabIndex = 149;
            this.rbtnBuscarM.TabStop = true;
            this.rbtnBuscarM.Text = "Buscar por medico";
            this.rbtnBuscarM.UseVisualStyleBackColor = true;
            this.rbtnBuscarM.CheckedChanged += new System.EventHandler(this.rbtnBuscarM_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbSede);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbProgram);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(12, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(465, 88);
            this.panel3.TabIndex = 150;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnBuscar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 35;
            this.btnBuscar.Location = new System.Drawing.Point(1027, 94);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnBuscar.Size = new System.Drawing.Size(39, 36);
            this.btnBuscar.TabIndex = 151;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.MouseLeave += new System.EventHandler(this.btnBuscar_MouseLeave);
            this.btnBuscar.MouseHover += new System.EventHandler(this.btnBuscar_MouseHover);
            // 
            // FormCord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 720);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.dgCola);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1084, 0);
            this.Name = "FormCord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desprendible";
            this.Load += new System.EventHandler(this.FormCord_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCola)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtMed;
        private Label label5;
        private DateTimePicker dateTimeFechaini;
        private DateTimePicker dateTimeFechaFin;
        private Label label6;
        private Panel panel2;
        private Label label7;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private DataGridView dgCola;
        private ComboBox cmbSede;
        private ComboBox cmbProgram;
        private ComboBox cmbFechas;
        private RadioButton rbtnBuscarFecha;
        private SplitContainer splitContainer1;
        private RadioButton rbtnBuscarM;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton btnBuscar;
    }
}