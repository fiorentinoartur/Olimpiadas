using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using webDesktop2020.Modal;
using webDesktop2020.Properties;

namespace webDesktop2020
{
    public partial class LoginForm : parent
    {
        Settings settings = Settings.Default;
        public LoginForm()
        {
            InitializeComponent();
            Txt_Email.Leave += TxtTexto_Leave; 
        }

        private void TxtTexto_Leave(object sender, EventArgs e)
        {
            var email = ctx.Usuarios.FirstOrDefault(x => x.Email == Txt_Email.Text);
            if (email == null)
            {
                return;
            }
            if (email.perfil == ADM)
            {
                
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Email.Text) || string.IsNullOrEmpty(Txt_Senha.Text))
            {
                MessageBox.Show("Empty email or password");
                return;
            }
            var user = ctx.Usuarios.FirstOrDefault(x => x.Email == Txt_Email.Text);

            if (user == null)
            {
                MessageBox.Show("Email or Password not valid");
                return;

            }
            Dados.Logged = user;
            settings.keep = checkBox1.Checked;
            settings.idUser = user.Id;
            settings.Save();

            if (user.perfil == "0") new Form1().Show();

            this.Hide();
        }

        private void forgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var email = ctx.Usuarios.FirstOrDefault(x => x.Email == Txt_Email.Text);

            if (email == null) 
            {
                MessageBox.Show("Invalid Email");
                return;
            }

        }

        private void linkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
