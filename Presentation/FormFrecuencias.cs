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
using Microsoft.VisualBasic.ApplicationServices;

namespace Presentation
{
    public partial class FormFrecuencias : Form
    {
        string Contrat = ""; //Variable para almacenar el texto del cmbprograma
        public FormFrecuencias()
        {
            InitializeComponent();
            ListarContratos();
        }
        private void ListarContratos()
        {
            // Corregir consulta
            PatientModel Contrato = new PatientModel();
            var validConsul = Contrato.ConsultarContratoAllInd();
            if (validConsul == true)
            {
                cmbProgram.DataSource = null;
                //cmbProgram.DataSource = PatientsCache.TablaAllContratos;
                cmbProgram.DataSource = PatientsCache.TablaContratosInd;
                cmbProgram.DisplayMember = "contrato";
                cmbProgram.ValueMember = "id";

            }
            else
            {
                cmbProgram.DataSource = null;
            }

        }

        private void cmbProgram_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Contrat = this.cmbProgram.SelectedValue.ToString();
            
                // Corregir consulta
                ServicesModel Services = new ServicesModel();
            var validConsul = Services.ConsultarServicios(this.Contrat); //this.Contrat);
            if (validConsul == true)
            {
                cmbServicio.DataSource = null;  
                cmbServicio.DataSource = ServicesCache.TablaServices;
                cmbServicio.DisplayMember = "nombre";
                cmbServicio.ValueMember = "id";

            }
            else
            {
                cmbServicio.DataSource = null;
            }
            try
            {
                // Consultar topes
                ServicesModel topes = new ServicesModel();
                var validConsul2 = topes.ConsultarTopes(this.Contrat); //this.Contrat);
                if (validConsul2 == true)
                {
                    dgTope.DataSource = null;
                    dgTope.DataSource = ServicesCache.TablaTopes;
                    this.dgTope.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dgTope.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    this.dgTope.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgTope.Visible = true;

                }
                else
                {
                    dgTope.DataSource = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");

            }
            

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            if (txtTope.Text != "")
            {
                var UpdateT = new ServicesModel(id: Convert.ToInt32(this.dgTope.SelectedRows[0].Cells[0].Value), cantidad: txtTope.Text);
                var result = UpdateT.EditCTope();
                MessageBox.Show(result);

                this.dgTope.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgTope.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgTope.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTope.Text != "")
            {
                var UpdateT = new ServicesModel(idServicio: Convert.ToInt32(this.cmbServicio.SelectedValue.ToString()), idContrato: Convert.ToInt32(this.cmbProgram.SelectedValue.ToString()), cantidadI: txtTope.Text);
            var result = UpdateT.InsertTopeI();
                MessageBox.Show(result);
                /*
                this.dgTope.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgTope.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgTope.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;*/
            }
        }
    }
}
