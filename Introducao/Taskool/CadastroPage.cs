using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taskool.Modal;

namespace Taskool
{
    public partial class CadastroPage : Form
    {
        // Objeto de entidade para interação com o banco de dados
        dbTarefasEntities ctx = new dbTarefasEntities();

        public CadastroPage()
        {
            InitializeComponent();
            // Configura o destaque nos campos de texto quando entrarem ou saírem do foco
            ConfigurarDestaqueCamposTexto();
        }

        private void ConfigurarDestaqueCamposTexto()
        {
            // Adiciona manipuladores de eventos Enter e Leave para cada campo de texto
            Txt_Email.Enter += DestacarCampoTexto;
            Txt_Email.Leave += ResetarCampoTexto;

            Txt_Nome.Enter += DestacarCampoTexto;
            Txt_Nome.Leave += ResetarCampoTexto;

            Txt_Telefone.Enter += DestacarCampoTexto;
            Txt_Telefone.Leave += ResetarCampoTexto;

            Txt_Usuario.Enter += DestacarCampoTexto;
            Txt_Usuario.Leave += ResetarCampoTexto;
        }

        private void DestacarCampoTexto(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Destaca o campo de texto quando entra em foco
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.BackColor = Color.LightBlue;
            }
        }

        private void ResetarCampoTexto(object sender, EventArgs args)
        {
            if (sender is TextBox textBox)
            {
                // Retorna ao estilo padrão quando o campo perde o foco
                textBox.BorderStyle = BorderStyle.Fixed3D;
                textBox.BackColor = SystemColors.Window;
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos necessários foram preenchidos
            if (Txt_Email.Text == "" || Txt_Usuario.Text == "" || Txt_Nome.Text == "" || Txt_Telefone.Text == "")
            {
                MessageBox.Show("Preencha os campos corretamente");
                return;
            }

            // Verifica se o e-mail já está cadastrado no banco de dados
            var validarEmail = ctx.Usuario.FirstOrDefault(x => x.Email == Txt_Email.Text);
            if (validarEmail != null)
            {
                MessageBox.Show("Email já cadastrado");
                return;
            }

            // Verifica se o e-mail segue o padrão da indústria
            if (!EmailPadrao(Txt_Email.Text))
            {
                MessageBox.Show("O email não segue o padrão da indústria");
                return;
            }

            // Verifica se o telefone contém apenas dígitos
            if (!ValidarTelefone(Txt_Telefone.Text.Trim()))
            {
                MessageBox.Show("O telefone deve conter apenas digitos");
                return;
            }

            // Cria um novo objeto de usuário e preenche com os dados do formulário
            Usuario user = new Usuario();
            user.Email = Txt_Email.Text;
            user.Usuario1 = Txt_Usuario.Text;
            user.Nome = Txt_Nome.Text;
            user.Telefone = Txt_Telefone.Text;

            // Converte a imagem para um array de bytes se uma imagem estiver presente
            if (pictureBox1.Image != null)
            {
                ImageConverter cvt = new ImageConverter();
                byte[] binaryImage = (byte[])cvt.ConvertTo(pictureBox1.Image, typeof(byte[]));
                user.Foto = binaryImage;
            }

            // Adiciona o usuário ao contexto do banco de dados e salva as alterações
            ctx.Usuario.Add(user);
            ctx.SaveChanges();

            MessageBox.Show("Usuário Cadastrado com sucesso!!");
            // Limpa os campos após o cadastro
            Txt_Email.Text = "";
            Txt_Usuario.Text = "";
            Txt_Nome.Text = "";
            Txt_Telefone.Text = "";
            pictureBox1.Image = Image.FromFile("C:\\Users\\Artur Fiorentino\\Downloads\\1 - Taskool - Nacional 2018\\1 - Taskool - Nacional 2018\\sessao_1\\DataFilesS01\\user.png");
        }
        private Image RotacionarImagem(Image imagem)
        {
            if(Array.IndexOf(imagem.PropertyIdList,274) > -1)
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
        private void button2_Click(object sender, EventArgs e)
        {
            // Abre uma janela de diálogo para selecionar uma imagem
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.png;*.jpg;*) | *.png;*.jpg;*";
            ofd.Title = "Imagem Selecionada";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Carrega a imagem selecionada no PictureBox
                string imagePath = ofd.FileName;
                Image imagemSelecionada = Image.FromFile(imagePath);
                imagemSelecionada = RotacionarImagem(imagemSelecionada);

                pictureBox1.Image = imagemSelecionada;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gera uma sugestão de nome de usuário com base no nome e data de nascimento
            string fullName = Txt_Nome.Text.Trim().ToLower();
            string birthDate = dateTimePicker1.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(birthDate))
            {
                MessageBox.Show("Preencha o campo de nome e data de nascimento corretamente");
                return;
            }

            string sugestaoUsuario = GerarSugestaoUsuario(fullName, birthDate);

            if (sugestaoUsuario != null)
            {
                Txt_Usuario.Text = sugestaoUsuario;
            }
            else
            {
                MessageBox.Show("Não foi possível gerar aleatório");
            }
        }

        private string GerarSugestaoUsuario(string fullName, string birthDate)
        {
            // Gera uma sugestão de nome de usuário com base no nome e sobrenome
            string[] partName = fullName.Split(' ');

            if (partName.Length < 2)
            {
                MessageBox.Show("O nome deve conter pelo menos um sobrenome");
                return null;
            }

            string firstName = partName[0];
            string lastName = partName[partName.Length - 1];

            string doisUltimoDigitosAno = birthDate.Substring(birthDate.Length - 2);
            string sugestaoUsuario = $"{firstName}.{lastName}{doisUltimoDigitosAno}";

            // Verifica se a sugestão de usuário já existe no banco de dados
            if (UsuariojaExiste(sugestaoUsuario))
            {
                sugestaoUsuario = $"{firstName}.{partName[partName.Length - 2]}{doisUltimoDigitosAno}";

                // Se a segunda sugestão também existe, retorna nulo
                if (UsuariojaExiste(sugestaoUsuario))
                {
                    return null;
                }
            }
            return sugestaoUsuario;
        }

        private bool UsuariojaExiste(string sugestaoUsurio)
        {
            // Verifica se o usuário já existe no banco de dados
            var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Nome == sugestaoUsurio);
            return usuarioBuscado != null;
        }

        private bool EmailPadrao(string email)
        {
            // Verifica se o e-mail segue o padrão da indústria
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private bool ValidarTelefone(string telefone)
        {
            // Verifica se o telefone contém apenas dígitos
            return telefone.All(char.IsDigit);
        }
    }
}
