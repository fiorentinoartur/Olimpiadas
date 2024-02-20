using FiorentionoDesktop.Model;
using FiorentionoDesktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
   
    public partial class LoginForm : FiorentionoDesktop.parent
    {
        Settings settings = Settings.Default;
        public LoginForm()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox1.Text = $"{logado.Email}" ;
            textBox2.Text = "teste123";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox2.Text != logado.Senha)
            {
                "Senha Incorreta!".Alert();
                textBox2.Text = "";
                return;
            }

            "Boas Vindas".Information();
            new PrincipalForm().Show();
            this.Hide();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPass().Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                settings.keep = true;
                settings.idUser = logado.IdUsuario;
            }
            else
            {
                settings.keep = false;
                settings.idUser = 0;
            }
            settings.Save();
        }
    }
}
