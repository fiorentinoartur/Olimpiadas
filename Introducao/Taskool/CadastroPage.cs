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
        dbTarefasEntities ctx = new dbTarefasEntities();
        public CadastroPage()
        {
            InitializeComponent();
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {

            if (Txt_Email.Text == "" || Txt_Usuario.Text == "" || Txt_Nome.Text == "" || Txt_Telefone.Text == "")
            {
                MessageBox.Show("Preencha os campos corretamente");
                return;
            }

            var validarEmail = ctx.Usuario.FirstOrDefault(x => x.Email == Txt_Email.Text);

            if (validarEmail != null)
            {
                MessageBox.Show("Email já cadastrado");
                return;
            }

            if (!EmailPadrao(Txt_Email.Text))
            {
                MessageBox.Show("O email não segue o padrão da indústria");
                return;
            }

            if (!ValidarTelefone(Txt_Telefone.Text.Trim()))
            {
                MessageBox.Show("O telefone deve conter apenas digitos");
                return;
            }


            Usuario user = new Usuario();

            user.Email = Txt_Email.Text;    
            user.Usuario1 = Txt_Usuario.Text;
            user.Nome = Txt_Nome.Text;
            user.Telefone = Txt_Telefone.Text;

            if (pictureBox1.Image != null)
            {
                ImageConverter cvt = new ImageConverter();
                byte[] binaryImage = (byte[])cvt.ConvertTo(pictureBox1.Image, typeof(byte[]));

                user.Foto = binaryImage;    
            }

            ctx.Usuario.Add(user);
            ctx.SaveChanges();

            MessageBox.Show("Usuário Cadastrado com sucesso!!");
            // Limpar os campos após o cadastro
            Txt_Email.Text = "";
            Txt_Usuario.Text = "";
            Txt_Nome.Text = "";
            Txt_Telefone.Text = "";
            pictureBox1.Image = Image.FromFile("C:\\Users\\Artur Fiorentino\\Downloads\\1 - Taskool - Nacional 2018\\1 - Taskool - Nacional 2018\\sessao_1\\DataFilesS01\\user.png");
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.png;*.jpg;*) | *.png;*.jpg;*";
            ofd.Title = "Imagem Selecionada";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = ofd.FileName;

                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            if (UsuariojaExiste(sugestaoUsuario))
            {
                sugestaoUsuario = $"{firstName}.{partName[partName.Length - 2]}{doisUltimoDigitosAno}";

                if (UsuariojaExiste(sugestaoUsuario))
                {
                    return null;
                }
            }
            return sugestaoUsuario;
        }


        private bool UsuariojaExiste(string sugestaoUsurio)
        {
        var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Nome == sugestaoUsurio);

            return usuarioBuscado != null;
        }

        private bool EmailPadrao(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);    
        }

        private bool ValidarTelefone(string telefone)
        {
            return telefone.All(char.IsDigit);
        }
    }
}
