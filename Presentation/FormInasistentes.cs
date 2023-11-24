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
    public partial class FormInasistentes : Form
    {
        public string dgselect = "";
        string Contrat = ""; //Variable para almacenar el texto del cmbprograma
        string Espec = ""; //Variable para almacenar el texto del cmbEspecialidad
        public FormInasistentes()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //this.dateTimeFechaFin.Value = DateTime.Today.AddDays(+60);//asignar fechas predeterminadas a los datetimer
            //this.dateTimeFechaini.Value = DateTime.Today.AddDays(-60);
            this.Contrat = "";
            this.Espec = "";
            ListarContratos();
            ListarEspecialidades();
            Cargarcmb();
        }

        private void Cargarcmb() {
            cmbfiltro.Items.Add("TODOS");
            cmbfiltro.Items.Add("NO PROGRAMADO");
            cmbfiltro.Items.Add("CONFIRMADO");
            cmbfiltro.Items.Add("EN ATENCION");
            cmbfiltro.Items.Add("INASISTENTE");
            cmbfiltro.Items.Add("INASISTENTE - PERSISTENTE");
            cmbfiltro.Items.Add("AGENDADO");
            cmbfiltro.Items.Add("ATENDIDO - NO PROGRAMADO");
            cmbfiltro.Items.Add("ATENDIDO - AGENDADO");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                PatientModel Inasis = new PatientModel();

                var validConsul = Inasis.ConsultarInasistentes(this.txtId.Text, this.txtNombre.Text, this.txtService.Text, this.Contrat, this.Espec);
                if (validConsul == true)
                {
                    this.dgInasistentes.DataSource = null;
                    this.dgInasistentes.DataSource = CitasCache.TablaInasistentes;
                    //this.dgInasistentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    this.dgInasistentes.Columns[0].Width = 50;
                    this.dgInasistentes.Columns[1].Width = 50;
                    this.dgInasistentes.Columns[2].Width = 250;
                    this.dgInasistentes.Columns[3].Width = 150;
                    this.dgInasistentes.Columns[4].Width = 100;
                    this.dgInasistentes.Columns[5].Width = 100;
                    this.dgInasistentes.Columns[6].Width = 120;
                    this.dgInasistentes.Columns[7].Width = 180;
                }
                else
                {
                    this.dgInasistentes.DataSource = null;
                }
            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
            lbCount.Text = "Total: " + dgInasistentes.RowCount.ToString();
        }

        private void ListarContratos()
        {
            try
            {
                PatientModel Contrato = new PatientModel();
                var validConsul = Contrato.ConsultarContratoAll();
                if (validConsul == true)
                {
                    cmbProgram.DataSource = null;
                    cmbProgram.DataSource = PatientsCache.TablaAllContratos;
                    cmbProgram.DisplayMember = "contrato";

                }
                else
                {
                    cmbProgram.DataSource = null;
                }
            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
        }

        private void ListarEspecialidades()
        {
            try
            {
                PatientModel E = new PatientModel();
                var validConsul = E.ConsultarEspecialidad();
                if (validConsul == true)
                {
                    cmbEspecialidad.DataSource = null;
                    cmbEspecialidad.DataSource = PatientsCache.TablaEspecialidades;
                    cmbEspecialidad.DisplayMember = "descripcion";
                    cmbEspecialidad.ValueMember = "id";

                }
                else
                {
                    cmbEspecialidad.DataSource = null;
                }
            }
            catch (Exception)
            {

                //throw;
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
            }
        }
        //
        private void SemaforizarColumnas(DataGridView dg, DataGridViewCellFormattingEventArgs e)
        {
            if (dg.Columns[e.ColumnIndex].Name == "ESTADO DE CITA")
            {
                if ((e.Value.ToString() == "NO PROGRAMADO"))
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else
                {
                    if ((e.Value.ToString() == "INASISTENTE"))
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        if ((e.Value.ToString() == "INASISTENTE - PERSISTENTE"))
                        {
                            e.CellStyle.ForeColor = Color.DarkRed;
                        }
                        else {
                            if ((e.Value.ToString() == "AGENDADO"))
                            {
                                e.CellStyle.ForeColor = Color.RoyalBlue;
                            }
                            else
                            {
                                if ((e.Value.ToString() == "ATENDIDO - NO PROGRAMADO"))
                                {
                                    e.CellStyle.ForeColor = Color.DarkGreen;
                                }
                                else
                                {
                                    if ((e.Value.ToString() == "ATENDIDO - AGENDADO"))
                                    {
                                        e.CellStyle.ForeColor = Color.ForestGreen;
                                    }

                                }
                            }
                        }
                    }
                }
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

        private void dgInasistentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SemaforizarColumnas(dgInasistentes, e);
        }


        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidad.Text == "TODAS LAS ESPECIALIDADES")
            {
                this.Espec = "";
            }
            else
            {
                if (cmbEspecialidad.Text == "GRUPO - MEDICINA GENERAL")
                {
                    this.Espec = "MEDICINA";
                }
                else
                {
                    this.Espec = this.cmbEspecialidad.Text;
                }
            }
        }

        //Metodo para exportar datos del dt a excel
        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, verifique si tiene instalado Microsoft Excel");
            }
        }


        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarDataGridViewExcel(dgInasistentes);
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error, verifique si tiene instalado Microsoft Excel");
            }

        }

        private void cmbfiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgInasistentes.Visible == true)
                {
                    string filterField = "ESTADO DE CITA";
                    ((DataTable)dgInasistentes.DataSource).DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterField, cmbfiltro.Text);

                    lbCount.Text = "Total: " + dgInasistentes.RowCount.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe realizar una busqueda antes de filtrar");
            }
        }

        private void dgInasistentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormMenu);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormMenu();
            frm.ShowDialog();
        }

        private void dgInasistentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgselect = dgInasistentes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                FormMenu fM = new FormMenu();
                PatientModel Criterio = new PatientModel();
                var validConsul = Criterio.ConsultarC(dgselect);
                if (validConsul == true)
                {

                    fM.textBox1.Text = PatientsCache.NombreC;
                    fM.richTextBox1.Text = PatientsCache.Observacion;

                }
                else
                {
                    if (PatientsCache.NombreC == "" && PatientsCache.Observacion == "")
                    {
                        dgselect = "";
                        fM.textBox1.Text = "";
                        fM.richTextBox1.Text = "";

                    }
                    
                }
            }
            catch (Exception)
            {

                //MessageBox.Show("Se ha presentado algún error");
            }
            
        }

    }
}
