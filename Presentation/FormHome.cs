using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Common.Cache;
using Domain;

namespace Presentation
{
    public partial class FormHome : Form

    {
        bool sidebarExpand;
        public FormHome()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btninicio_Click(null ,e);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = true;
        }

        private void btnrptventa_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void btnrptcompra_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void btnrptpagos_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
           
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new productos());
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new inicio());
        }

        private void BTNventas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormCord());
        }

        private void LoadUserData()
        {
            lbUser.Text = UserLoginCache.User;
            LbUserName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            lbPosition.Text = UserLoginCache.Position;
            lbEmail.Text = UserLoginCache.Email;
            //lbconnection.Text = Convert.ToString("Última conexión: " + UserLoginCache.LastConnetcion);
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {

                //if sidebar is expand minimize
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {

                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else {

                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width) {
                    sidebarExpand = true;
                    sidebarTimer.Stop();

                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormPatients());
        }
    }
}
