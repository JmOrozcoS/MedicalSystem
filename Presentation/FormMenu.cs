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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.richTextBox1.Text = "";
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void escenario1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FormPrincipal FHome = new FormPrincipal();
            FHome.Show();

        }

        private void formPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void escenario2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void FormMenu_MouseLeave(object sender, EventArgs e)
        {
            //this.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = PatientsCache.NombreC;
            this.richTextBox1.Text = PatientsCache.Observacion;

        }
    }
}
