using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
        public Form1()
        {
            InitializeComponent();
            Txt_Usuario.ShortcutsEnabled = false;
            capslock_Login.Visible = false;
        }

        dbTarefasEntities ctx = new dbTarefasEntities();

        private void Txt_Cadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CadastroPage().Show();

            Hide();
        }
        private void link_Teclado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {

                Process.Start(@"C:\\Windows\System32\osk.exe");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao abrir o teclado virtual: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsKeyLocked(Keys.CapsLock))
            {
                capslock_Login.Visible = true;
            }
            else
            {
                capslock_Login.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.png;*.jpeg*;) | *.png;*.jpeg*;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            // Obtém o usuário com base no nome de usuário fornecido
            var usuario = ctx.Usuario.FirstOrDefault(x => x.Usuario1 == Txt_Usuario.Text);

            if (usuario == null)
            {
                MessageBox.Show("Usuário não encontrado");
                Console.Beep(1000, 1000);
                return;
            }
            // Converte a imagem do PictureBox em um array de bytes
            byte[] imagemSelecionada = ConverterImagem(pictureBox1.Image);

            // Obtém a imagem do usuário armazenada no banco de dados
            byte[] imagemBd = usuario.Foto;

            // Compara as imagens
            if (!CompararImagem(imagemSelecionada, imagemBd))
            {
                MessageBox.Show("Imagem  incorreta");
                Console.Beep(1000,1000);
                return;
            }

            MessageBox.Show($"Seja bem-vindo {usuario.Usuario1}");

            Txt_Usuario.Text = "";
            pictureBox1.Image = Image.FromFile(@"C:\Users\Artur Fiorentino\Downloads\DataFilesS01-20231221T193344Z-001\DataFilesS01\user.png");
            MessageBox.Show($"{usuario.Codigo}");
            new PrincipalPage(usuario.Codigo).Show();

            Hide();
        }

        // Converte uma imagem em um array de bytes
        private byte[] ConverterImagem(Image image)
        {
            // Cria um MemoryStream para armazenar os bytes da imagem
            var stream = new MemoryStream();

            // Salva a imagem no formato original no MemoryStream
            image.Save(stream,image.RawFormat);

            // Retorna os bytes da imagem
            return stream.ToArray();
        }

        // Compara dois arrays de bytes para verificar se são iguais
        private bool CompararImagem(byte[] image1, byte[] image2)
        {
            // Compara diretamente os arrays de bytes
            return image1.SequenceEqual(image2);
        }
    }
}
