using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Model;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ModuloDesktopEntities ctx = new ModuloDesktopEntities();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Entrar_Click(object sender, EventArgs e)
        {
         var buscaUsuario = ctx.Usuarios.FirstOrDefault(x => x.email == Txt_Email.Text && x.senha == Txt_Senha.Text);

            if (buscaUsuario != null)
            {
                MessageBox.Show($"Usuário Logado com sucesso, seja bem vindo ${buscaUsuario.apelido}!");
                return;
            }

            MessageBox.Show("Senha ou Email inválido!!!");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form2().ShowDialog();   
        }
    }
}
