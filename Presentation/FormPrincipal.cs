using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Presentation
{
    public partial class FormPrincipal : Form
    {

        bool sidebarExpand;
        public FormPrincipal()
        {
            InitializeComponent();
            LoadUserData();
        }


        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (this.lbPosition.Text != "ADMIN JUNIOR")
            {
                this.btnMenu3.Enabled = false;
                this.btnMenu3.Visible = false;
                this.btnMenu4.Enabled = false;
                this.btnMenu4.Visible = false;
            }
            else {
                this.btnMenu3.Enabled = true;
                this.btnMenu3.Visible = true;
                this.btnMenu4.Enabled = true;
                this.btnMenu4.Visible = true;
            }
        }
        #region Funcionalidades del formulario
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        /*private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;*/

        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }


        /*protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Transparent);
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        */


        private void ocultarsubmenus(Panel p1, Panel p2, Panel p3, Panel p4) { 
            p1.Visible = true;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.panelMenu1.Visible)
            {
                this.panelMenu1.Visible = false;
            }
            else
            {
                this.panelMenu1.Visible = true;
                ocultarsubmenus(panelMenu1, panelMenu2, panelMenu3, panelMenu4);
            }

            EstablecerFondo(btnMenu1, btnMenu2, btnMenu3, btnMenu4);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormPatients>();
        }
        private void btnSubmenu2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormInasistentes>();
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            if (this.panelMenu2.Visible)
            {
                this.panelMenu2.Visible = false;
            }
            else
            {
                this.panelMenu2.Visible = true;
                ocultarsubmenus(panelMenu2, panelMenu1, panelMenu3, panelMenu4);
            }

            EstablecerFondo(btnMenu2, btnMenu1, btnMenu3, btnMenu4);
        }
        private void btn1Submenu2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCord>();
        }

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            if (this.panelMenu3.Visible)
            {
                this.panelMenu3.Visible = false;
            }
            else
            {
                this.panelMenu3.Visible = true;
                ocultarsubmenus(panelMenu3, panelMenu2, panelMenu1, panelMenu4);
            }
            EstablecerFondo(btnMenu3, btnMenu1, btnMenu2, btnMenu4);
        }

        private void btnMenu4_Click(object sender, EventArgs e)
        {
            if (this.panelMenu4.Visible)
            {
                this.panelMenu4.Visible = false;
            }
            else
            {
                this.panelMenu4.Visible = true;
                ocultarsubmenus(panelMenu4, panelMenu2, panelMenu3, panelMenu1);
            }
            //AbrirFormulario<FormFrecuencias>();
            EstablecerFondo(btnMenu4, btnMenu1, btnMenu2, btnMenu3);
        }


        private void EstablecerFondo(FontAwesome.Sharp.IconButton Bp, FontAwesome.Sharp.IconButton Bs1, FontAwesome.Sharp.IconButton Bs2, FontAwesome.Sharp.IconButton Bs3) {
            Bp.BackColor = Color.FromArgb(82, 54, 147);
            Bp.ForeColor = Color.White;
            Bp.IconColor = Color.White;

            Bs1.BackColor = Color.Transparent;
            Bs1.ForeColor = Color.FromArgb(255, 255, 255);
            Bs1.IconColor = Color.FromArgb(255, 255, 255);

            Bs2.BackColor = Color.Transparent;
            Bs2.ForeColor = Color.FromArgb(255, 255, 255);
            Bs2.IconColor = Color.FromArgb(255, 255, 255);

            Bs3.BackColor = Color.Transparent;
            Bs3.ForeColor = Color.FromArgb(255, 255, 255);
            Bs3.IconColor = Color.FromArgb(255, 255, 255);
        }

        


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

 

        /*private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que dese salir?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
            }
        }*/
        //Capturar posicion y tamaño antes de maximizar para restaurar
        /*int lx, ly;
        int sw, sh;*/

        /*private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }*/

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (this.Width <= 1300 )
            {

                //if sidebar is expand minimize
                this.btnMenu1.Text = "";
                this.btnMenu2.Text = "";
                this.btnMenu3.Text = "";
                this.btnMenu4.Text = "";
                this.btnPsalir.Text = "";
                this.LbUserName.Text = "";
                this.lbUser.Text = "";
                this.lbPosition.Text = "";
                this.lbEmail.Text = "";
                panelMenu.Width -= 10;
                if (panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {

                panelMenu.Width += 10;
                if (panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    this.btnMenu1.Text = "   PACIENTES";
                    this.btnMenu2.Text = "   COORDINACION";
                    this.btnMenu3.Text = "   CAC";
                    this.btnMenu4.Text = "   ADMINISTRACION";
                    this.btnPsalir.Text = "   Cerrar Sesión";
                    lbUser.Text = UserLoginCache.User;
                    LbUserName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
                    lbPosition.Text = UserLoginCache.Position;
                    lbEmail.Text = UserLoginCache.Email;

                    sidebarExpand = true;
                    sidebarTimer.Stop();
                    

                }
            }
        }

        private void LoadUserData()
        {
            lbUser.Text = UserLoginCache.User;
            LbUserName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            lbPosition.Text = UserLoginCache.Position;
            lbEmail.Text = UserLoginCache.Email;
        }

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPsalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que dese cerrar sesión?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                FormLogin fLogin = new FormLogin();
                fLogin.Show();
                this.Hide();
            }
            else if (result == DialogResult.No)
            {
            }
        }


        #endregion
        //METODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL
        private void AbrirFormulario<MiForm>() where MiForm : Form, new() {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender,FormClosedEventArgs e) {
            if (Application.OpenForms["FormPatients"] == null)
                btnMenu1.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["FormCord"] == null)
                btnMenu2.BackColor = Color.FromArgb(4, 41, 68);
        }

        private void FormPrincipal_Resize(object sender, EventArgs e)
        {
            if (Width <= 1300)
            {
                sidebarTimer.Start();
            }
            else {
                if (this.Width > 1300 | this.WindowState == FormWindowState.Maximized)
                {
                    sidebarTimer.Start();
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormFrecuencias>();
        }


        private void linkLbEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirFormulario<FormUsers>();
        }
    }
}
