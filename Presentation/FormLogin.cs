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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.txtcontrasena.Focus();
            //this.lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
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

        private void btLogin_Click(object sender, EventArgs e)
        {

            if (txtuser.Text != "")
            {
                if (txtcontrasena.Text != "")
                {
                    try
                    {
                        UserModel user = new UserModel();
                        var validlogin = user.LoginUser(txtuser.Text, txtcontrasena.Text);
                        if (validlogin == true)
                        {
                            if (UserLoginCache.Estado != "X")
                            {
                                FormPrincipal formP = new FormPrincipal();
                                formP.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usario inactivo");
                                txtcontrasena.Clear();
                                txtcontrasena.Focus();
                            }
                            
                        }
                        else
                        {
                            msgerror("Usuario o contraseña incorrecta");
                            txtcontrasena.Clear();
                            txtcontrasena.Focus();
                        }
                    }
                    catch (Exception)
                    {

                        //throw;
                        MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
                    }                 
                }
                else msgerror("Por favor ingrese una contraseña");
                }
                else msgerror("Por favor ingrese un usuario");
            
        }

        private void msgerror(String msg)
        {
            Errorlb.Text = " " + msg;
            Errorlb.Visible = true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
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

        private void lnNameApp_Click(object sender, EventArgs e)
        {

        }

        private void txtcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                //aqui codigo
                if (txtuser.Text != "")
                {
                    if (txtcontrasena.Text != "")
                    {
                        try
                        {
                            UserModel user = new UserModel();
                            var validlogin = user.LoginUser(txtuser.Text, txtcontrasena.Text);
                            if (validlogin == true)
                            {
                                if (UserLoginCache.Estado != "X")
                                {
                                    FormPrincipal formP = new FormPrincipal();
                                    formP.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Usario inactivo");
                                    txtcontrasena.Clear();
                                    txtcontrasena.Focus();
                                }

                            }
                            else
                            {
                                msgerror("Usuario o contraseña incorrecta");
                                txtcontrasena.Clear();
                                txtcontrasena.Focus();
                            }
                        }
                        catch (Exception)
                        {

                            //throw;
                            MessageBox.Show("No se ha podido conectar a la Base de Datos contacte con el administrador");
                        }
                    }
                    else msgerror("Por favor ingrese una contraseña");
                }
                else msgerror("Por favor ingrese un usuario");

            }
        }
        
    }
    
}
