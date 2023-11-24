using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Domain;

namespace Presentation
{
    public partial class FormPatients : Form
    {
        string DataSelect = ""; //Variable para almacenar el texto de la seleccion del dgCola
        string Contrat = ""; //Variable para almacenar el texto del cmbprograma
        string Profesionales = ""; //Variable para almacenar el texto del cmbProfesionales

        public FormPatients()
        {
            InitializeComponent();
            CargarElementos(); //LLamar al metodo
        }

        private void FormPatients_Load(object sender, EventArgs e)
        {

            this.Contrat = "";
            this.Profesionales = "Todos";
            this.cmbProgram.Text = "Todos los contratos";
            this.dateTimeFechaFin.Value = DateTime.Today.AddDays(+180);//asignar fechas predeterminadas a los datetimer
            this.dateTimeFechaini.Value = DateTime.Today.AddDays(-365);
            this.lbId.Location = new System.Drawing.Point(8, 73);
            this.txtId.Location = new System.Drawing.Point(8, 92);
            this.lbName.Location = new System.Drawing.Point(164, 73);
            this.txtNombre.Location = new System.Drawing.Point(164, 92);
            this.dgCola.Location = new System.Drawing.Point(8, 121);
            //Ejecutar icon Lab
            EstablecerFondoMenu(this.iconButton1, this.iconButton2, this.iconButton3);
            this.cmbProfesionales.Visible = false;
            this.panelParamedicos.Visible = false;
            this.PanelMedicosx1.Visible = false;
            this.dgLab.Visible = true;
            this.txtLab.Visible = true;
            this.lbLab.Visible = true;
            this.btnLab.Visible = true;
            this.lbContrato.Visible = true;
            this.cmbProgram.Visible = true;
            this.dgProced.Visible = false;
            this.txtProced.Visible = false;
            this.btnProced.Visible = false;
            this.lbProced.Visible = false;
            this.lbFechaini.Visible = true;
            this.lbFehcafin.Visible = true;
            this.dateTimeFechaini.Visible = true;
            this.dateTimeFechaFin.Visible = true;
            this.dateTimeFechaini.Enabled = false;
            this.dateTimeFechaFin.Enabled = false;
            this.dgCitas.Visible = false;
            this.txtCita.Visible = false;
            this.btnCita.Visible = false;
            this.lbCita.Visible = false;
            // FIN

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Cerrar sesion
            FormMenu formM = new FormMenu();
            formM.Show();
            this.Hide();

        }

        private void CargarElementos()
        {

            //Limpiar campos
            txtId.Text = "";
            txtNombre.Text = "";

        }

        private void ItemMenuSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que dese salir?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                UserModel patient = new UserModel();
                var validConsul = patient.ConsultarPaciente(txtId.Text, txtNombre.Text);
                if (validConsul == true)
                {
                    this.dgCola.DataSource = null;
                    this.dgCola.DataSource = PatientsCache.Tabla;
                    //Ancho automatico Datagrid
                    //this.dgCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    this.dgCola.Columns[0].Width = 100;
                    this.dgCola.Columns[1].Width = 150;
                }
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                UserModel patient = new UserModel();
                var validConsul = patient.ConsultarPaciente(txtId.Text, txtNombre.Text);
                if (validConsul == true)
                {
                    this.dgCola.DataSource = null;
                    this.dgCola.DataSource = PatientsCache.Tabla;
                    //Ancho automatico Datagrid
                    //this.dgCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    this.dgCola.Columns[0].Width = 100;
                    this.dgCola.Columns[1].Width = 150;
                }
            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                UserModel lab = new UserModel();
                var validConsul = lab.ListarLaboratorios(this.DataSelect, txtLab.Text, this.Contrat);
                if (validConsul == true)
                {
                    //Insertar datos en datagrid
                    this.dgLab.DataSource = null;
                    this.dgLab.DataSource = PatientsCache.Tablalab;
                    //
                    /*var result = from row in dgLab.Rows.Cast<DataGridViewRow>()
                                 group row by Convert.ToString(row.Cells["Nombre del Servicio"].Value) into g
                                 where g.Count() > 1
                                 select new
                                 {
                                     key = g.Key,
                                     row = g.First()
                                 };*/
                    //
                    this.dgLab.Columns[0].Width = 100;
                    this.dgLab.Columns[1].Width = 20;
                    this.dgLab.Columns[2].Width = 20;
                    this.dgLab.Columns[3].Width = 85;
                    this.btnFilterOK.Visible = true;
                    this.btnFilterP.Visible = true;
                    this.btnFilterV.Visible = true;
                }
                else
                {
                    this.dgLab.DataSource = null;
                    this.btnFilterOK.Visible = false;
                    this.btnFilterP.Visible = false;
                    this.btnFilterV.Visible = false;
                }
            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
        }
        private void FormPatients_Resize(object sender, EventArgs e)
        {
            if (this.Width < 1480)
            {
                this.txtNombre.Width = 283;
                this.dgCola.Width = 439;
                this.panelDpaciente.Width = 439;
                this.lbRiesgo.Location = new Point(4,34);
                this.lbRiesgo.Anchor = AnchorStyles.None;
                this.lbMedT.Location = new Point(4, 64);
            }
            else
            {
                this.txtNombre.Width = 606;
                this.dgCola.Width = 762;
                this.panelDpaciente.Width = 762;
                this.lbRiesgo.Location = new Point(520, 0);
                this.lbRiesgo.Anchor = AnchorStyles.Top;
                this.lbRiesgo.Anchor = AnchorStyles.Right;
                this.lbMedT.Location = new Point(4, 34);

            }
        }

        private void dgLab_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgLab, e);
        }




        private void EstablecerFondoMenu(FontAwesome.Sharp.IconButton Bp, FontAwesome.Sharp.IconButton Bs1, FontAwesome.Sharp.IconButton Bs2)
        {
            Bp.BackColor = Color.FromArgb(136, 136, 136);
            Bp.ForeColor = Color.FromArgb(255, 255, 255);
            Bp.IconColor = Color.FromArgb(255, 255, 255);

            Bs1.BackColor = Color.FromArgb(36, 41, 46);
            Bs1.ForeColor = Color.FromArgb(255,255,255);
            Bs1.IconColor = Color.FromArgb(255, 255, 255);

            Bs2.BackColor = Color.FromArgb(36, 41, 46);
            Bs2.ForeColor = Color.FromArgb(255, 255, 255);
            Bs2.IconColor = Color.FromArgb(255, 255, 255);

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            EstablecerFondoMenu(this.iconButton1, this.iconButton2, this.iconButton3);

            this.cmbProfesionales.Visible = false;
            this.panelParamedicos.Visible = false;
            this.PanelMedicosx1.Visible = false;
            this.dgLab.Visible = true;
            this.txtLab.Visible = true;
            this.lbLab.Visible = true;
            this.btnLab.Visible = true;
            this.lbContrato.Visible = true;
            this.cmbProgram.Visible = true;

            this.dgProced.Visible = false;
            this.txtProced.Visible = false;
            this.btnProced.Visible = false;
            this.lbProced.Visible = false;
            this.lbFechaini.Visible = true;
            this.lbFehcafin.Visible = true;
            this.dateTimeFechaini.Visible = true;
            this.dateTimeFechaFin.Visible = true;
            this.dateTimeFechaini.Enabled = false;
            this.dateTimeFechaFin.Enabled = false;

            this.dgCitas.Visible = false;
            this.txtCita.Visible = false;
            this.btnCita.Visible = false;
            this.lbCita.Visible = false;

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            EstablecerFondoMenu(this.iconButton2, this.iconButton1, this.iconButton3);

            this.cmbProfesionales.Visible = false;
            this.panelParamedicos.Visible = false;
            this.PanelMedicosx1.Visible = false;
            this.dgLab.Visible = false;
            this.txtLab.Visible = false;
            this.lbLab.Visible = false;
            this.btnLab.Visible = false;

            this.dgProced.Visible = true;
            this.txtProced.Visible = true;
            this.btnProced.Visible = true;
            this.lbProced.Visible = true;
            this.lbFechaini.Visible = true;
            this.lbFehcafin.Visible = true;
            this.dateTimeFechaini.Visible = true;
            this.dateTimeFechaFin.Visible = true;
            this.dateTimeFechaini.Enabled = true;
            this.dateTimeFechaFin.Enabled = true;

            this.lbContrato.Visible = true;
            this.cmbProgram.Visible = true;
            //this.btnFilterOK.Visible = true;
            //this.btnFilterP.Visible = true;
            //this.btnFilterV.Visible = true;

            this.dgCitas.Visible = false;
            this.txtCita.Visible = false;
            this.btnCita.Visible = false;
            this.lbCita.Visible = false;



        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            this.cmbProfesionales.Visible = true;
            if (this.cmbProfesionales.Text.Equals(""))
            {
                this.cmbProfesionales.Text = "Todos";
                this.panelParamedicos.Visible = false;
                this.PanelMedicosx1.Visible = false;
            }
            else 
            {
                this.cmbProfesionales.Text = this.Profesionales;
                if (this.cmbProfesionales.Text.Equals("Paramedicos"))
                {
                    this.panelParamedicos.Visible = true;
                    this.PanelMedicosx1.Visible = false;
                }
                if (this.cmbProfesionales.Text.Equals("Medicos"))
                    {
                       this.panelParamedicos.Visible = false;
                       this.PanelMedicosx1.Visible = true;
                    }
                if (this.cmbProfesionales.Text.Equals("Todos"))
                {
                    this.panelParamedicos.Visible = false;
                    this.PanelMedicosx1.Visible = false;
                    this.dgCitas.Visible = true;
                }
            }
            EstablecerFondoMenu(this.iconButton3, this.iconButton1, this.iconButton2);
            this.dgLab.Visible = false;
            this.txtLab.Visible = false;
            this.lbLab.Visible = false;
            this.btnLab.Visible = false;

            //this.dgCitas.Visible = true;
            this.txtCita.Visible = true;
            this.btnCita.Visible = true;
            this.lbCita.Visible = true;
            this.lbFechaini.Visible = true;
            this.lbFehcafin.Visible = true;
            this.dateTimeFechaini.Visible = true;
            this.dateTimeFechaFin.Visible = true;
            this.dateTimeFechaini.Enabled = true;
            this.dateTimeFechaFin.Enabled = true;

            this.lbContrato.Visible = true;
            this.cmbProgram.Visible = true;
            //this.btnFilterOK.Visible = true;
            //this.btnFilterP.Visible = true;
            //this.btnFilterV.Visible = true;

            this.dgProced.Visible = false;
            this.txtProced.Visible = false;
            this.btnProced.Visible = false;
            this.lbProced.Visible = false;
        }
        private void dgCola_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            this.lbId.Location = new System.Drawing.Point(8, 176);
            this.txtId.Location = new System.Drawing.Point(8, 195);
            this.lbName.Location = new System.Drawing.Point(164, 176);
            this.txtNombre.Location = new System.Drawing.Point(164, 195);
            this.dgCola.Location = new System.Drawing.Point(8, 224);

            panelDpaciente.Visible = true;
            //panelDpaciente.Height = 100;
            string? id = this.dgCola.SelectedRows[0].Cells[0].Value.ToString();
            string? nId = this.dgCola.SelectedRows[0].Cells[1].Value.ToString();
            string? names = this.dgCola.SelectedRows[0].Cells[2].Value.ToString();
            this.lbNombres.Text = "Paciente: " + names;
            string identify = id + nId.ToString();
            this.DataSelect = identify;
            string? labCarga = "CARGA VIRAL";
            try
            {

                //ListarContratos();
                PatientModel Contrato = new PatientModel();
                var validConsul = Contrato.ConsultarContrato(this.DataSelect);
                if (validConsul == true)
                {
                    cmbProgram.DataSource = null;
                    cmbProgram.DataSource = PatientsCache.TablaContratos;
                    cmbProgram.DisplayMember = "contrato";
                    //cmbProgram.ValueMember = "id";

                }
                else
                {
                    cmbProgram.DataSource = null;
                }


                UserModel riesgo = new UserModel();

                var validConsulR = riesgo.ConsultarRiesgo(this.DataSelect, labCarga);
                if (validConsulR == true)
                {
  
                    if (PatientsCache.MedicoT == (null))
                    {
                        lbMedT.Text = "Medico tratante: No asignado";
                    }
                    else {
                        lbMedT.Text = "Medico tratante: " + PatientsCache.MedicoT;
                    }
                    
                    this.lbRiesgo.Text = PatientsCache.Riesgo;

                    string R = PatientsCache.Riesgo;
                    string s2 = "Copias/mL";
                    bool b = R.Contains(s2);
                    if (b)
                    {
                        int index = R.IndexOf(s2);
                        if (index >= 0)
                        {
                            this.lbRiesgo.ForeColor = Color.Red;
                        }
                        else {

                            this.lbRiesgo.ForeColor = Color.DarkSlateGray;
                        }
                    }
                    else
                    {
                        this.lbRiesgo.ForeColor = Color.DarkSlateGray;
                    }
                }
                else
                {
                    lbRiesgo.Text = "Riesgo: N/A";

                    this.lbRiesgo.ForeColor = Color.DarkSlateGray;
                    lbMedT.Text = "Medico tratante: No asignado";
                }     
               
            }
            catch (Exception)
            {

                //return;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
        }

        private void btnCita_Click(object sender, EventArgs e)
        {
            try
            {
            if (this.Profesionales == "Paramedicos")
            {
                this.panelParamedicos.Visible = false;
                PatientModel CitaO = new PatientModel();
                var validConsul = CitaO.ConsultarCitasOdon(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                dgCitas.Visible = false;
                if (validConsul == true)
                {
                    try
                    {
                        this.dgOdon.Columns.Remove("1");
                    }
                    catch (Exception)
                    {

                    }

                    this.dgOdon.DataSource = null;
                    this.dgOdon.DataSource = CitasCache.TablaCparamedicos;
                    RedimencionarDatagrid(this.dgOdon);
                    this.dgOdon.Visible = true;
                }
                else
                {
                    try
                    {
                        this.dgOdon.DataSource = null;
                        this.dgOdon.Columns.Remove("1");
                        this.dgOdon.Columns.Add("1", "ODONTOLOGIA SIN REALIZAR");
                        RedimencionarDatagrid(this.dgOdon);
                        //this.dgCParamedicos.Visible = false;
                    }
                    catch (Exception)
                    {
                        this.dgOdon.DataSource = null;
                        this.dgOdon.Columns.Add("1", "ODONTOLOGIA SIN REALIZAR");
                        RedimencionarDatagrid(this.dgOdon);
                        //this.dgCParamedicos.Visible = false;
                    }

                }
                //
                PatientModel CitaP = new PatientModel();
                var validConsulP = CitaP.ConsultarCitasPsico(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                if (validConsulP == true)
                {
                    try
                    {
                        this.dgPsico.Columns.Remove("1");
                    }
                    catch (Exception)
                    {

                    }

                    this.dgPsico.DataSource = null;
                    this.dgPsico.DataSource = CitasCache.TablaCpsico;
                    RedimencionarDatagrid(this.dgPsico);
                    this.dgPsico.Visible = true;
                }
                else
                {
                    try
                    {
                        this.dgPsico.DataSource = null;
                        this.dgPsico.Columns.Remove("1");
                        this.dgPsico.Columns.Add("1", "PSICOLOGIA SIN REALIZAR");
                        RedimencionarDatagrid(this.dgPsico);
                        //this.dgCParamedicos.Visible = false;
                    }
                    catch (Exception)
                    {
                        this.dgPsico.DataSource = null;
                        this.dgPsico.Columns.Add("1", "PSICOLOGIA SIN REALIZAR");
                        RedimencionarDatagrid(this.dgPsico);
                        //this.dgCParamedicos.Visible = false;
                    }
                }
                //
                PatientModel CitaQ = new PatientModel();
                var validConsulQ = CitaQ.ConsultarCitasQuimi(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                if (validConsulQ == true)
                {
                    try
                    {
                        this.dgQuimico.Columns.Remove("1");
                    }
                    catch (Exception)
                    {

                    }

                    this.dgQuimico.DataSource = null;
                    this.dgQuimico.DataSource = CitasCache.TablaCQuimi;
                    RedimencionarDatagrid(this.dgQuimico);
                    this.dgQuimico.Visible = true;
                }
                else
                {
                    try
                    {
                        this.dgQuimico.DataSource = null;
                        this.dgQuimico.Columns.Remove("1");
                        this.dgQuimico.Columns.Add("1", "QUIMICO SIN REALIZAR");
                        RedimencionarDatagrid(this.dgQuimico);
                        //this.dgCParamedicos.Visible = false;
                    }
                    catch (Exception)
                    {
                        this.dgQuimico.DataSource = null;
                        this.dgQuimico.Columns.Add("1", "QUIMICO SIN REALIZAR");
                        RedimencionarDatagrid(this.dgQuimico);
                        //this.dgCParamedicos.Visible = false;
                    }
                }

                //
                PatientModel CitaN = new PatientModel();
                var validConsulN = CitaN.ConsultarCitasNurti(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                if (validConsulN == true)
                {
                    try
                    {
                        this.dgNutri.Columns.Remove("1");
                    }
                    catch (Exception)
                    {

                    }

                    this.dgNutri.DataSource = null;
                    this.dgNutri.DataSource = CitasCache.TablaCNurti;
                    RedimencionarDatagrid(this.dgNutri);
                    this.dgNutri.Visible = true;
                }
                else
                {
                    try
                    {
                        this.dgNutri.DataSource = null;
                        this.dgNutri.Columns.Remove("1");
                        this.dgNutri.Columns.Add("1", "NUTRICION SIN REALIZAR");
                        RedimencionarDatagrid(this.dgNutri);
                        //this.dgCParamedicos.Visible = false;
                    }
                    catch (Exception)
                    {
                        this.dgNutri.DataSource = null;
                        this.dgNutri.Columns.Add("1", "NUTRICION SIN REALIZAR");
                        RedimencionarDatagrid(this.dgNutri);
                        //this.dgCParamedicos.Visible = false;
                    }

                }
                //
                PatientModel CitaE = new PatientModel();
                var validConsulE = CitaE.ConsultarCitasEnfer(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                if (validConsulE == true)
                {
                    try
                    {
                        this.dgEnfer.Columns.Remove("1");
                    }
                    catch (Exception)
                    {

                    }

                    this.dgEnfer.DataSource = null;
                    this.dgEnfer.DataSource = CitasCache.TablaCEnfer;
                    RedimencionarDatagrid(this.dgEnfer);
                    this.dgEnfer.Visible = true;
                }
                else
                {
                    try
                    {
                        this.dgEnfer.DataSource = null;
                        this.dgEnfer.Columns.Remove("1");
                        this.dgEnfer.Columns.Add("1", "ENFERMERIA SIN REALIZAR");
                        RedimencionarDatagrid(this.dgEnfer);
                        //this.dgCParamedicos.Visible = false;
                    }
                    catch (Exception)
                    {
                        this.dgEnfer.DataSource = null;
                        this.dgEnfer.Columns.Add("1", "ENFERMERIA SIN REALIZAR");
                        RedimencionarDatagrid(this.dgEnfer);
                        //this.dgCParamedicos.Visible = false;
                    }

                }
                //
                PatientModel CitaT = new PatientModel();
                var validConsulT = CitaT.ConsultarCitasTs(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                if (validConsulT == true)
                {
                    try
                    {
                        this.dgTs.Columns.Remove("1");
                    }
                    catch (Exception)
                    {

                    }

                    this.dgTs.DataSource = null;
                    this.dgTs.DataSource = CitasCache.TablaCTs;
                    RedimencionarDatagrid(this.dgTs);
                    this.dgTs.Visible = true;
                }
                else
                {
                    try
                    {
                        this.dgTs.DataSource = null;
                        this.dgTs.Columns.Remove("1");
                        this.dgTs.Columns.Add("1", "TRABAJO SOCIAL SIN REALIZAR");
                        RedimencionarDatagrid(this.dgTs);
                        //this.dgCParamedicos.Visible = false;
                    }
                    catch (Exception)
                    {
                        this.dgTs.DataSource = null;
                        this.dgTs.Columns.Add("1", "TRABAJO SOCIAL SIN REALIZAR");
                        RedimencionarDatagrid(this.dgTs);
                        //this.dgCParamedicos.Visible = false;
                    }

                }
                this.PanelMedicosx1.Visible = false;
                this.panelParamedicos.Visible = true;
            }
            else
            {
                if (this.Profesionales == "Medicos")
                {
                    this.panelParamedicos.Visible = false;
                    this.PanelMedicosx1.Visible = true;

                    PatientModel CitaG = new PatientModel();
                    var validConsulCg = CitaG.ConsultarCitasG(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                    this.dgCitas.Visible = false;
                    this.panelParamedicos.Visible = false;
                    if (validConsulCg == true)
                    {
                        try
                        {
                            this.dgMgeneral.Columns.Remove("1");
                        }
                        catch (Exception)
                        {

                        }

                        this.dgMgeneral.DataSource = null;
                        this.dgMgeneral.DataSource = CitasCache.TablaCMgeneral;
                        RedimencionarDatagrid(this.dgMgeneral);
                        this.dgMgeneral.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            this.dgMgeneral.DataSource = null;
                            this.dgMgeneral.Columns.Remove("1");
                            this.dgMgeneral.Columns.Add("1", "M. GENERAL SIN REALIZAR");
                            RedimencionarDatagrid(this.dgMgeneral);
                            //this.dgCParamedicos.Visible = false;
                        }
                        catch (Exception)
                        {
                            this.dgMgeneral.DataSource = null;
                            this.dgMgeneral.Columns.Add("1", "M. GENERAL SIN REALIZAR");
                            RedimencionarDatagrid(this.dgMgeneral);
                            //this.dgCParamedicos.Visible = false;
                        }
                        
                    }

                    //

                    PatientModel CitaInter = new PatientModel();
                    var validConsulCI = CitaInter.ConsultarCitasI(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                    this.dgCitas.Visible = false;
                    this.panelParamedicos.Visible = false;
                    if (validConsulCI == true)
                    {
                        try
                        {
                            this.dgMinterna.Columns.Remove("1");
                        }
                        catch (Exception)
                        {

                        }

                        this.dgMinterna.DataSource = null;
                        this.dgMinterna.DataSource = CitasCache.TablaCMinterna;
                        RedimencionarDatagrid(this.dgMinterna);
                        this.dgMinterna.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            this.dgMinterna.DataSource = null;
                            this.dgMinterna.Columns.Remove("1");
                            this.dgMinterna.Columns.Add("1", "M. INTERNA SIN REALIZAR");
                            RedimencionarDatagrid(this.dgMinterna);
                            //this.dgCParamedicos.Visible = false;
                        }
                        catch (Exception)
                        {
                            this.dgMinterna.DataSource = null;
                            this.dgMinterna.Columns.Add("1", "M. GENERAL SIN REALIZAR");
                            RedimencionarDatagrid(this.dgMinterna);
                            //this.dgCParamedicos.Visible = false;
                        }

                    }

                    //

                    PatientModel CitaInfecto = new PatientModel();
                    var validConsulCInf = CitaInfecto.ConsultarCitasInfecto(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                    this.dgCitas.Visible = false;
                    this.panelParamedicos.Visible = false;
                    if (validConsulCInf == true)
                    {
                        try
                        {
                            this.dgInfecto.Columns.Remove("1");
                        }
                        catch (Exception)
                        {

                        }

                        this.dgInfecto.DataSource = null;
                        this.dgInfecto.DataSource = CitasCache.TablaCinfecto;
                        RedimencionarDatagrid(this.dgInfecto);
                        this.dgInfecto.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            this.dgInfecto.DataSource = null;
                            this.dgInfecto.Columns.Remove("1");
                            this.dgInfecto.Columns.Add("1", "M. INTERNA SIN REALIZAR");
                            RedimencionarDatagrid(this.dgInfecto);
                            //this.dgCParamedicos.Visible = false;
                        }
                        catch (Exception)
                        {
                            this.dgInfecto.DataSource = null;
                            this.dgInfecto.Columns.Add("1", "M. GENERAL SIN REALIZAR");
                            RedimencionarDatagrid(this.dgInfecto);
                            //this.dgCParamedicos.Visible = false;
                        }

                    }


                    //

                    this.panelParamedicos.Visible = false;
                    this.PanelMedicosx1.Visible = true;

                }
                else
                {

                    UserModel Cita = new UserModel();
                    var validConsul = Cita.ListarCitas(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtCita.Text, this.Contrat);
                    this.panelParamedicos.Visible = false;
                    this.PanelMedicosx1.Visible = false;
                    this.dgCitas.Visible = true;
                    if (validConsul == true)
                    {

                        this.dgCitas.DataSource = null;
                        this.dgCitas.DataSource = PatientsCache.TablaCitas;

                        this.dgCitas.Columns[0].Width = 200;
                        this.dgCitas.Columns[1].Width = 90;
                        this.dgCitas.Columns[2].Width = 90;
                        this.dgCitas.Columns[3].Width = 90;
                        this.dgCitas.Columns[4].Width = 60;

                        this.btnFilterOK.Visible = true;
                        this.btnFilterP.Visible = true;
                        this.btnFilterV.Visible = true;

                    }
                    else
                    {
                        this.dgCitas.DataSource = null;
                        this.btnFilterOK.Visible = false;
                        this.btnFilterP.Visible = false;
                        this.btnFilterV.Visible = false;
                    }
                }
            }
            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
        }


        private void btnProced_Click(object sender, EventArgs e)
        {
            try
            {
                UserModel Proced = new UserModel();
                var validConsul = Proced.ListarProcedimientos(this.DataSelect, this.dateTimeFechaini.Value, this.dateTimeFechaFin.Value, this.txtProced.Text, this.Contrat);
                if (validConsul == true)
                {
                    this.dgProced.DataSource = null;
                    this.dgProced.DataSource = PatientsCache.TablaProced;

                    this.dgProced.Columns[0].Width = 200;
                    this.dgProced.Columns[1].Width = 90;
                    this.dgProced.Columns[2].Width = 90;
                    this.dgProced.Columns[3].Width = 90;
                    this.dgProced.Columns[4].Width = 60;
                    this.btnFilterOK.Visible = true;
                    this.btnFilterP.Visible = true;
                    this.btnFilterV.Visible = true;
                }
                else
                {
                    this.dgProced.DataSource = null;
                    this.btnFilterOK.Visible = false;
                    this.btnFilterP.Visible = false;
                    this.btnFilterV.Visible = false;
                }
            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
        }

        private void SemaforizarColumnas(DataGridView dg, DataGridViewCellFormattingEventArgs e) {
            if (dg.Columns[e.ColumnIndex].Name == "Estado")
            {
                if ((e.Value.ToString() == "VENCIDO"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    if ((e.Value.ToString() == "POR VENCER"))
                    {
                        e.CellStyle.ForeColor = Color.Orange;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                }
            }
        }


        private void dgCitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgCitas, e);
        }
        private void dgProced_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgProced, e);
        }
        private void dgMgeneral_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgMgeneral, e);
        }
        private void dgMinterna_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgMinterna, e);
        }
        private void dgInfecto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgInfecto, e);
        }
        private void dgNutri_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgNutri, e);
        }
        private void dgOdon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgOdon, e);
        }
        private void dgPsico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgPsico, e);
        }
        private void dgQuimico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgQuimico, e);
        }
        private void dgTs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgTs, e);
        }

        //metodo para establecer fondo de los botones de filtro
        /*private void backButton(FontAwesome.Sharp.IconButton b1, FontAwesome.Sharp.IconButton b2, FontAwesome.Sharp.IconButton b3)
        {

            b1.BackColor = Color.FromArgb(242, 104, 104);
            b1.ForeColor = Color.White;
            b1.IconColor = Color.White;

            b2.BackColor = Color.Transparent;
            b2.ForeColor = Color.Coral;
            b2.IconColor = Color.Coral;

            b3.BackColor = Color.Transparent;
            b3.ForeColor = Color.LimeGreen;
            b3.IconColor = Color.LimeGreen;
        }*/

        private void btnFilterV_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLab.Visible == true)
                {
                    string filterField = "Estado";
                    ((DataTable)dgLab.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterV.Text);

                    btnFilterV.BackColor = Color.FromArgb(242, 104, 104);
                    btnFilterV.ForeColor = Color.White;
                    btnFilterV.IconColor = Color.White;

                    btnFilterP.BackColor = Color.Transparent;
                    btnFilterP.ForeColor = Color.Coral;
                    btnFilterP.IconColor = Color.Coral;

                    btnFilterOK.BackColor = Color.Transparent;
                    btnFilterOK.ForeColor = Color.LimeGreen;
                    btnFilterOK.IconColor = Color.LimeGreen;
                }
                else
                {
                    if (dgProced.Visible == true)
                    {
                        string filterField = "Estado";
                        ((DataTable)dgProced.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterV.Text);

                        btnFilterV.BackColor = Color.FromArgb(242, 104, 104);
                        btnFilterV.ForeColor = Color.White;
                        btnFilterV.IconColor = Color.White;

                        btnFilterP.BackColor = Color.Transparent;
                        btnFilterP.ForeColor = Color.Coral;
                        btnFilterP.IconColor = Color.Coral;

                        btnFilterOK.BackColor = Color.Transparent;
                        btnFilterOK.ForeColor = Color.LimeGreen;
                        btnFilterOK.IconColor = Color.LimeGreen;
                    }
                    else
                    {
                        if (dgCitas.Visible == true)
                        {
                            string filterField = "Estado";
                            ((DataTable)dgCitas.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterV.Text);

                            btnFilterV.BackColor = Color.FromArgb(242, 104, 104);
                            btnFilterV.ForeColor = Color.White;
                            btnFilterV.IconColor = Color.White;

                            btnFilterP.BackColor = Color.Transparent;
                            btnFilterP.ForeColor = Color.Coral;
                            btnFilterP.IconColor = Color.Coral;

                            btnFilterOK.BackColor = Color.Transparent;
                            btnFilterOK.ForeColor = Color.LimeGreen;
                            btnFilterOK.IconColor = Color.LimeGreen;
                        }
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe realizar una busqueda antes de filtrar");
            }


        }

        private void btnFilterP_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLab.Visible == true)
                {
                    string filterField = "Estado";
                    ((DataTable)dgLab.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterP.Text);

                    btnFilterP.BackColor = Color.FromArgb(242, 198, 104);
                    btnFilterP.ForeColor = Color.White;
                    btnFilterP.IconColor = Color.White;

                    btnFilterV.BackColor = Color.Transparent;
                    btnFilterV.ForeColor = Color.Red;
                    btnFilterV.IconColor = Color.Red;

                    btnFilterOK.BackColor = Color.Transparent;
                    btnFilterOK.ForeColor = Color.LimeGreen;
                    btnFilterOK.IconColor = Color.LimeGreen;
                }
                else
                {
                    if (dgProced.Visible == true)
                    {
                        string filterField = "Estado";
                        ((DataTable)dgProced.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterP.Text);

                        btnFilterP.BackColor = Color.FromArgb(242, 198, 104);
                        btnFilterP.ForeColor = Color.White;
                        btnFilterP.IconColor = Color.White;

                        btnFilterV.BackColor = Color.Transparent;
                        btnFilterV.ForeColor = Color.Red;
                        btnFilterV.IconColor = Color.Red;

                        btnFilterOK.BackColor = Color.Transparent;
                        btnFilterOK.ForeColor = Color.LimeGreen;
                        btnFilterOK.IconColor = Color.LimeGreen;
                    }
                    else
                    {
                        if (dgCitas.Visible == true)
                        {
                            string filterField = "Estado";
                            ((DataTable)dgCitas.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterP.Text);

                            btnFilterP.BackColor = Color.FromArgb(242, 198, 104);
                            btnFilterP.ForeColor = Color.White;
                            btnFilterP.IconColor = Color.White;

                            btnFilterV.BackColor = Color.Transparent;
                            btnFilterV.ForeColor = Color.Red;
                            btnFilterV.IconColor = Color.Red;

                            btnFilterOK.BackColor = Color.Transparent;
                            btnFilterOK.ForeColor = Color.LimeGreen;
                            btnFilterOK.IconColor = Color.LimeGreen;
                        }
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe realizar una busqueda antes de filtrar");
            }
        
        }

        private void btnFilterOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLab.Visible == true)
                {
                    string filterField = "Estado";
                    ((DataTable)dgLab.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterOK.Text);

                    btnFilterOK.BackColor = Color.FromArgb(104, 242, 166);
                    btnFilterOK.ForeColor = Color.White;
                    btnFilterOK.IconColor = Color.White;

                    btnFilterP.BackColor = Color.Transparent;
                    btnFilterP.ForeColor = Color.Coral;
                    btnFilterP.IconColor = Color.Coral;

                    btnFilterV.BackColor = Color.Transparent;
                    btnFilterV.ForeColor = Color.Red;
                    btnFilterV.IconColor = Color.Red;
                }
                else
                {
                    if (dgProced.Visible == true)
                    {
                        string filterField = "Estado";
                        ((DataTable)dgProced.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterOK.Text);

                        btnFilterOK.BackColor = Color.FromArgb(104, 242, 166);
                        btnFilterOK.ForeColor = Color.White;
                        btnFilterOK.IconColor = Color.White;

                        btnFilterP.BackColor = Color.Transparent;
                        btnFilterP.ForeColor = Color.Coral;
                        btnFilterP.IconColor = Color.Coral;

                        btnFilterV.BackColor = Color.Transparent;
                        btnFilterV.ForeColor = Color.Red;
                        btnFilterV.IconColor = Color.Red;
                    }
                    else
                    {
                        if (dgCitas.Visible == true)
                        {
                            string filterField = "Estado";
                            ((DataTable)dgCitas.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, btnFilterOK.Text);

                            btnFilterOK.BackColor = Color.FromArgb(104, 242, 166);
                            btnFilterOK.ForeColor = Color.White;
                            btnFilterOK.IconColor = Color.White;

                            btnFilterP.BackColor = Color.Transparent;
                            btnFilterP.ForeColor = Color.Coral;
                            btnFilterP.IconColor = Color.Coral;

                            btnFilterV.BackColor = Color.Transparent;
                            btnFilterV.ForeColor = Color.Red;
                            btnFilterV.IconColor = Color.Red;
                        }
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe realizar una busqueda antes de filtrar");
            }
            
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbProgram.Text == "Todos los contratos")
            {
                this.Contrat = "";
            }
            else
            {
                if (this.cmbProgram.Text == "SERVIHDA")
                {
                    this.Contrat = "INTEG";
                }
                else
                {
                    if (this.cmbProgram.Text == "SER RESILIENTE")
                    {
                        this.Contrat = ") SR";
                    }
                    else
                    {
                        if (this.cmbProgram.Text == "AMARTE")
                        {
                            this.Contrat = "AR ";
                        }
                        else
                        {
                            if (this.cmbProgram.Text == "EVENTO")
                            {
                                this.Contrat = "EVEN";
                            }
                            else
                            {
                                if (this.cmbProgram.Text == "RESPIRA")
                                {
                                    this.Contrat = "EPOC";
                                }
                                else
                                {
                                    if (this.cmbProgram.Text == "CAPITA RUTA DE PYM")
                                    {
                                        this.Contrat = "CAPITA";
                                    }
                                    else
                                    {
                                        if (this.cmbProgram.Text == "RECUPERACION DE LA SALUD")
                                        {
                                            this.Contrat = "RECUPERACION";
                                        }
                                        else
                                        {
                                            this.Contrat = this.cmbProgram.Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
      
        //Metodo para ajustar la altura del datadrid segun cantidad de filas
        private void RedimencionarDatagrid(DataGridView dg)
        {
            int AltoGridIni = dg.Height;
            int AltoGrid = 0;
            int AltoForm = this.Height;
            int Diferencia;
            AltoGrid = AltoGrid + dg.ColumnHeadersHeight;

            for (int i = 0; i <= dg.Rows.Count - 1; i++)
            {
                AltoGrid = AltoGrid + dg.Rows[i].Height;
            }
            Diferencia = AltoGridIni - AltoGrid;

            if (Diferencia > 0)
            {
                AltoForm = AltoForm - Diferencia;
                this.Height = AltoForm;
            }
            else if (Diferencia < 0)
            {
                AltoForm = AltoForm + Diferencia;
                this.Height = AltoForm;
            }
            dg.Height = AltoGrid;
        }

        private void cmbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbProfesionales.Text == "Paramedicos")
            {
                this.Profesionales = "Paramedicos";
                this.panelParamedicos.Visible = true;
                this.PanelMedicosx1.Visible = false;
                this.dgCitas.Visible = false;
            }
            else
            {
                if (this.cmbProfesionales.Text == "Medicos")
                {
                    this.Profesionales = "Medicos";
                    this.panelParamedicos.Visible = false;
                    this.PanelMedicosx1.Visible = true;
                    this.dgCitas.Visible = false;
                }
                else
                {
                    if (this.cmbProfesionales.Text == "Todos")
                    {
                        this.Profesionales = "Todos";
                        this.panelParamedicos.Visible = false;
                        this.PanelMedicosx1.Visible = false;
                        this.dgCitas.Visible = true;
                    }
                }
            this.Profesionales = this.cmbProfesionales.Text;  
            }
        }
        
    }
}
        


