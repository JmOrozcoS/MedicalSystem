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
using DataAccess;

namespace Presentation
{
    public partial class FormCord : Form
    {

        string Contrat = ""; //Variable para almacenar el texto del cmbprograma
        string Sedess = ""; //Variable para almacenar el texto del cmbSede
        double xi;
        double yi;


        public FormCord()
        {
            InitializeComponent();

            
        }

        private void FormCord_Load(object sender, EventArgs e)
        {
            ListarContratos();
            ListarSedes();
            CargarElementos(); //LLamar al metodo
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMenu formM = new FormMenu();
            formM.Show();
            this.Hide();

        }

        private void CargarElementos()
        {
            cmbFechas.Items.Add("Hoy");
            cmbFechas.Items.Add("Este mes");
            cmbFechas.Items.Add("Este año");

        }

        private void ItemMenuRegistrar_Click(object sender, EventArgs e)
        {

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


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //instanciar clase y validar consulta
            UserModel patient = new UserModel();
            var validConsul = patient.Llenartabla(this.Sedess, txtMed.Text, this.Contrat, dateTimeFechaini.Value, dateTimeFechaFin.Value);
            if (validConsul == true)
            {
                try
                {  
                    this.dgCola.DataSource = null;
                    this.dgCola.DataSource = CitasCache.Tabla;
                    this.dgCola.Columns.Remove("N");
                    this.dgCola.Columns.Add("N", "Cumplimiento");
                    foreach (DataGridViewRow row in dgCola.Rows)
                    {
                        double valor = 0;
                        string valorF = "";
                        valor = Convert.ToDouble(row.Cells["ATENDIDOS"].Value) / Convert.ToDouble(row.Cells["TOTAL"].Value) * 100;
                        //valorF = valor.ToString("#,##0") + "%";
                        row.Cells["N"].Value = valor;
                    }

                }
                catch (Exception)
                {
                    this.dgCola.DataSource = null;
                    this.dgCola.DataSource = CitasCache.Tabla;
                    this.dgCola.Columns.Add("N", "Cumplimiento");                 
                    foreach (DataGridViewRow row in dgCola.Rows)
                    {
                        double valor = 0;
                        string valorF = "";
                        valor = Convert.ToDouble(row.Cells["ATENDIDOS"].Value) / Convert.ToDouble(row.Cells["TOTAL"].Value) * 100;
                        //valorF = valor.ToString("#,##0") + "%";
                        row.Cells["N"].Value = valor;
                    }
                   
                }

            }

            else
            {
                MessageBox.Show("No hay datos en el rango de fechas selecionado de: " + dateTimeFechaini.Value + " a " + dateTimeFechaFin.Value.ToString());

            }
        }


        // Metodo para llenar datos en combobox de consulta de sql
        private void ListarContratos()
        {
            CitasDao Contratos = new CitasDao();
            cmbProgram.DataSource = Contratos.ListarCONT();
            cmbProgram.DisplayMember = "contrato";
            //cmbProgram.ValueMember = "contrato";

        }

        private void ListarSedes()
        {
            CitasDao Sede = new CitasDao();
            cmbSede.DataSource = Sede.ListarSede();
            cmbSede.DisplayMember = "nombre";
            cmbSede.ValueMember = "nombre";
        }

        //Prueba
        private void cmbSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSede.Text == "Todas las sedes") {
                this.cmbSede.Text = "";
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

        private void rbtnBuscarM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBuscarM.Checked)
            {
                rbtnBuscarFecha.Checked = false;
                
                cmbFechas.Visible = false;
                dateTimeFechaini.Visible = false;
                dateTimeFechaFin.Visible = false;
            }
            else {
                rbtnBuscarFecha.Checked = true;
                
                cmbFechas.Visible = true;
                dateTimeFechaini.Visible = true;
                dateTimeFechaFin.Visible = true;
            }
            
        }

        private void rbtnBuscarFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBuscarFecha.Checked)
            {
                rbtnBuscarM.Checked = false;
                txtMed.Visible = false;

            }
            else
            {
                rbtnBuscarM.Checked = true;
                txtMed.Visible = true;
            }
        }

        private void btnBuscar_MouseHover(object sender, EventArgs e)
        {
            btnBuscar.IconColor = Color.DarkViolet;
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            btnBuscar.IconColor = Color.FromArgb(120, 120, 255);
        }

        private void cmbSede_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cmbSede.Text == "Todas las sedes")
            {
                this.Sedess = "";
            }
            else
            {
                this.Sedess = this.cmbSede.Text;
            }
        }

        private void dgCola_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (dgCola.Columns[e.ColumnIndex].Name.Equals("6"))
            {
                //Asegúrese de que el valor sea una cadena.
                String stringValue = e.Value as string;

                if (stringValue == null) return;

                e.Value = String.Format("{0:0.##}", e.Value);
            }*/
            try
            {
                dgCola.Columns[6].DefaultCellStyle.Format = "N0";
                /*foreach (DataGridViewRow row in dgCola.Rows)
                {
                    row.Cells["N"].Value = row.Cells["Cumplimiento"].Value + "%".ToString();
                }*/
            }
            catch (Exception)
            {

                //MessageBox.Show("Error");
            }

            SemaforizarColumnas(dgCola, e);

        }
        private void SemaforizarColumnas(DataGridView dg, DataGridViewCellFormattingEventArgs e)
        {
            /*if (dg.Columns[e.ColumnIndex].Name == "N")
            {
                if (e.Value.ToString() == "100")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    if (e.Value.ToString() == "100")
                    {
                        e.CellStyle.ForeColor = Color.Orange;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                }
            }*/

            if (this.dgCola.Columns[e.ColumnIndex].Name == "N")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        //Stock menor a 20
                        if (Convert.ToDouble(e.Value) <= 80)
                        {
                            //e.CellStyle.BackColor = Color.LightSalmon;
                            e.CellStyle.ForeColor = Color.Red;
                        }
                        //Stock menor a 10
                        if (Convert.ToDouble(e.Value) <= 70)
                        {
                            //e.CellStyle.BackColor = Color.Salmon;
                            e.CellStyle.ForeColor = Color.Red;
                        }
                        //Stock menor a 10
                        if (Convert.ToDouble(e.Value) > 80)
                        {
                            //e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.Green;
                        }
                    }
                    
                }
            }

        }
    }
}
