using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taskool.Modal;

namespace Taskool
{
    public partial class Form1 : Form
    {
        dbTarefasEntities ctx = new dbTarefasEntities();
        public Form1()
        {
            InitializeComponent();
            CapsLock.Visible = false;
            Txt_Usuario.KeyPress += Txt_Usuario_KeyPress;
        }


        private void Txt_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Control.ModifierKeys.HasFlag(Keys.Control) &&
                 (e.KeyChar == 'C' || e.KeyChar == 'X' || e.KeyChar == 'V'))
            {
                // Impede a cópia (CTRL+C), recorte (CTRL+X) e colagem (CTRL+V)
                e.Handled = true;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ***********SUGESTÃO PARA COLOCAR IMAGEM *******************


            //Definir o caminho da imagem incial

            //string caminhoImagem = "C:\\Users\\Artur Fiorentino\\Downloads\\1 - Taskool - Nacional 2018\\1 - Taskool - Nacional 2018\\sessao_1\\DataFilesS01\\user.png";

            //Carregar a imagem 

            //pictureBox1.Image = Image.FromFile(caminhoImagem);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Abrir teclado
            try
            {
                // Substitua "osk.exe" pelo caminho real do executável do teclado virtual no seu sistema
                Process.Start("C:\\Windows\\System32\\osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o teclado virtual: " + ex.Message);
            }
        }


        private void Txt_Usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var buscarUsuario = ctx.Usuario.FirstOrDefault(x => x.Usuario1 == Txt_Usuario.Text);

            if (buscarUsuario == null)
            {
                MessageBox.Show("Usuário Não encontrado");

                return;
            }


            Image imagemUsuario;
            using (MemoryStream ms = new MemoryStream(buscarUsuario.Foto))
            {
                imagemUsuario = Image.FromStream(ms);
            }

            pictureBox1.Image = imagemUsuario;
            MessageBox.Show($"Seja Bem-Vindo {buscarUsuario.Usuario1} ");
            new PrincipalPage(buscarUsuario.Codigo).Show();
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CadastroPage().Show();

     
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (IsKeyLocked(Keys.CapsLock))
            {
                CapsLock.Visible = true;
            }
            else
            {

                CapsLock.Visible = false;
            }
        }
    }
}
