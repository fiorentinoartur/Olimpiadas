using desktop2020.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop2020
{
    public partial class LoginForm : parent
    {
        Settings settings = Settings.Default;
        public LoginForm()
        {
            InitializeComponent();
            Txt_Email.Leave += TxtEmail_Leave;
            Txt_Senha.PasswordChar = '*';
            Txt_Email.Text = "administrador@email.com";
            Txt_Senha.Text = "admin123";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            var email = ctx.Usuarios.FirstOrDefault(x => x.Email == Txt_Email.Text);
            if (email == null) return;

            if (email.perfil == ADM)
                checkBox1.Enabled = false;
            else checkBox1.Enabled = true;
            checkBox1.Checked = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Email.Text) || string.IsNullOrEmpty(Txt_Senha.Text))
            {
                "Empty email or password".Alert();
                return;
            }
            var user = ctx.Usuarios.FirstOrDefault(x => x.Email == Txt_Email.Text && x.Senha == Txt_Senha.Text);
            if(user == null)
            {
                "Email or Password not valid".Alert();
                return;
            }
            Dados.Logged = user;
            settings.keep = checkBox1.Checked;
            settings.idUser = user.Id;
            settings.Save();

            if (user.perfil == "0") new AdmForm().Show();
            else new UserForm().Show();

            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var email = ctx.Usuarios.FirstOrDefault(x => x.Email == Txt_Email.Text);
            if(email == null) 
            {
                "Invalid email".Alert();
            }
            Dados.Logged = email;
                new ForgotPassForm().Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SingUpForm().Show();
        }
    }
}
