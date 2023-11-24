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
    public partial class FormUsers : Form
    {
        string Contrat = ""; //Variable para almacenar el texto del cmbprograma
        public FormUsers()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {

        }

        private void LoadUserData()
        {
            //View
            lbUser.Text = UserLoginCache.User;
            LbUserName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            lbPosition.Text = UserLoginCache.Position;
            lbEmail.Text = UserLoginCache.Email;

            //Panel
            txtUser.Text = UserLoginCache.User;
            txtPname.Text = UserLoginCache.FirstName;
            txtSname    .Text = UserLoginCache.Sname;
            txtPapellido.Text = UserLoginCache.LastName;
            txtSapellido.Text = UserLoginCache.Ssurname;
            txtEmail.Text = UserLoginCache.Email;
            txtPass.Text = UserLoginCache.Pass;
            txtCpass.Text = UserLoginCache.Pass;
            txtApass.Text = UserLoginCache.Pass;
            //txtPosition.Text = UserLoginCache.Position;


        }

        private void initializePassEidtControls() {
            linkPassEdit.Text = "Editar";
            txtPass.Enabled = false;
            txtPass.UseSystemPasswordChar = true;
            txtCpass.Enabled = false;
            txtCpass.UseSystemPasswordChar = true;
            txtApass.Enabled = false;
            txtApass.UseSystemPasswordChar = true;
        }
        private void reset() {
            LoadUserData();
            initializePassEidtControls();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //panel1.Anchor= AnchorStyles.Top | AnchorStyles.Right| AnchorStyles.Bottom;
            LoadUserData();
            reset();
        }

        private void linkPassEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkPassEdit.Text == "Editar")
            {
                linkPassEdit.Text = "Cancelar";
                txtPass.Enabled = true;
                txtPass.Text = "";
                txtCpass.Enabled = true;
                txtCpass.Text = "";
                txtApass.Enabled = true;
                txtApass.Text = "";
            }
            else if (linkPassEdit.Text=="Cancelar")
            {
                initializePassEidtControls();
                txtPass.Text = UserLoginCache.Pass;
                txtCpass.Text = UserLoginCache.Pass;
                txtApass.Text = UserLoginCache.Pass;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPass.Text.Length > 5)
            {
                if (txtPass.Text == txtCpass.Text)
                {
                    if (txtApass.Text == UserLoginCache.Pass)
                    {
                        var userModel = new UserModel(id: UserLoginCache.IdUser, user: txtUser.Text, pname: txtPname.Text, sname: txtSname.Text, papellido: txtPapellido.Text, sapellido: txtSapellido.Text, email: txtEmail.Text, pass: txtPass.Text/*, posicion: null*/);
                        var result = userModel.EditUserProfile();
                        MessageBox.Show(result);
                        reset();
                        panel1.Visible = false;
                    }
                    else
                        MessageBox.Show("Contraseña actual incorrecta");
                }
                else
                    MessageBox.Show("Las contraseñas no coinciden");
            }
            else
                MessageBox.Show("La contraseña no es fuerte");
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            reset();
        }
    }
}
