using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Taskool.Modal;

namespace Taskool
{
    public partial class Form1 : Form
    {
        // Instância do contexto do banco de dados
        private dbTarefasEntities ctx = new dbTarefasEntities();

        public Form1()
        {
            InitializeComponent();

            // Inicializações no construtor
            CapsLock.Visible = false;
            Txt_Usuario.Leave += fotoUsuario;
            Txt_Usuario.ShortcutsEnabled = false; // Desabilita atalhos Ctrl+C, Ctrl+V, Ctrl+X no TextBox
        }

        // Evento acionado quando o usuário clica no linkLabel para abrir o teclado virtual
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o teclado virtual: " + ex.Message);
            }
        }   

        // Evento acionado quando o usuário clica no botão "Entrar"
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Busca o usuário no banco de dados com base no texto no TextBox
            var buscarUsuario = ctx.Usuario.FirstOrDefault(x => x.Usuario1 == Txt_Usuario.Text);

            // Se o usuário não for encontrado, exibe uma mensagem
            if (buscarUsuario == null)
            {
                MessageBox.Show("Usuário Não encontrado");
                return;
            }

            // Exibe uma mensagem de boas-vindas com o nome do usuário
            MessageBox.Show($"Seja Bem-Vindo {buscarUsuario.Usuario1} ");

            // Abre a página principal passando o código do usuário como parâmetro
            new PrincipalPage(buscarUsuario.Codigo).Show();
        }

        // Evento acionado quando o usuário clica no linkLabel para abrir a página de cadastro
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CadastroPage().Show();
        }

        // Evento acionado periodicamente pelo timer para verificar o estado da tecla CapsLock
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Exibe ou oculta o indicador de CapsLock com base no estado da tecla CapsLock
            CapsLock.Visible = IsKeyLocked(Keys.CapsLock);
        }

        // Função para carregar a foto do usuário com base no texto no TextBox ao sair do campo
        private void fotoUsuario(object sender, EventArgs e)
        {
            // Busca o usuário no banco de dados com base no texto no TextBox
            var buscarUsuario = ctx.Usuario.FirstOrDefault(x => x.Usuario1 == Txt_Usuario.Text);

            // Se o usuário for encontrado, carrega a imagem do usuário no PictureBox
            if (buscarUsuario != null)
            {
                Image imagem = RotacionarImagem(Image.FromStream(new MemoryStream(buscarUsuario.Foto)));
                pictureBox1.Image = imagem;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // Função para rotacionar a imagem com base na orientação
        private Image RotacionarImagem(Image imagem)
        {
            // Verificar a orientação da imagem e rotacionar conforme necessário
            if (Array.IndexOf(imagem.PropertyIdList, 274) > -1)
            {
                var orientation = (int)imagem.GetPropertyItem(274).Value[0];
                if (orientation == 6)
                    imagem.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else if (orientation == 8)
                    imagem.RotateFlip(RotateFlipType.Rotate270FlipNone);
                else if (orientation == 3)
                    imagem.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }

            return imagem;
        }
    }
}