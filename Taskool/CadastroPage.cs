using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
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
            pictureBox1.Paint += PictureBox1_Paint;
            AplicarBordaCampos();

        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Cria um camilho eliptico
            GraphicsPath ellipsePath = new GraphicsPath();
            ellipsePath.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);

            //Definir a região da PictureBox para ser o caminho elíptico
            pictureBox1.Region = new Region(ellipsePath);
        }


        private void CadastroPage_Load(object sender, EventArgs e)
        {

        }
        private void ColocarBorda(Control campoTexto, Panel painel)
        {
            campoTexto.Enter += (sender, e) => painel.BackColor = Color.Blue;
            campoTexto.Leave += (sender, e) => painel.BackColor = SystemColors.Control;
        }

        private void AplicarBordaCampos()
        {
            ColocarBorda(Txt_Name, panel1);
            ColocarBorda(Txt_Email, panel2);
            ColocarBorda(Txt_Telefone, panel3);
            ColocarBorda(Txt_Usuario, panel4);
        }



        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            var buscarEmail = ctx.Usuario.FirstOrDefault(x => x.Email == Txt_Email.Text);

            if (buscarEmail != null)
            {
                MessageBox.Show("Email já cadastrado");
                return;
            }

            Usuario user = new Usuario();

            if (Txt_Email.Text == "" || Txt_Name.Text == "" || Txt_Telefone.Text == "" || Txt_Usuario.Text == "")
            {
                MessageBox.Show("Preencha todos os campos corretamente");
                return;
            }

            if (!validarEmail(Txt_Email.Text))
            {
                MessageBox.Show("Email não segue padrão da indústria");
                return;
            }
            if (!validarTelefone(Txt_Telefone.Text.Trim()))
            {
                MessageBox.Show("O telefone deve conter apenas digítos, sem espaços");
                return;
            }

            user.Email = Txt_Email.Text;
            user.Nome = Txt_Name.Text;
            user.Telefone = Txt_Telefone.Text;
            user.Usuario1 = Txt_Usuario.Text;

            if (pictureBox1.Image != null)
            {
                ImageConverter cvt = new ImageConverter();
                byte[] binaryImage = (byte[])cvt.ConvertTo(pictureBox1.Image, typeof(byte[]));

                user.Foto = binaryImage;
            }

            ctx.Usuario.Add(user);
            ctx.SaveChanges();

            MessageBox.Show("Usário cadastrado com sucesso!!!");


            Txt_Email.Text = "";
            Txt_Name.Text = "";
            Txt_Telefone.Text = "";
            Txt_Usuario.Text = "";
            pictureBox1.Image = Image.FromFile(@"C:\Users\Artur Fiorentino\Downloads\DataFilesS01-20231221T193344Z-001\DataFilesS01\user.png");




        }

        private bool validarEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.+[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);


            return regex.IsMatch(email);
        }
        private bool validarTelefone(string number)
        {
            return number.All(char.IsDigit);
        }

        private void Txt_Selecionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.png;*.jpg;*) | *.png;*.jpg;*";
            ofd.Title = "Imagens Selecionada";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                Image imagemRotacionada = Image.FromFile(imagePath);
                imagemRotacionada = rotacionarImagem(imagemRotacionada);

                pictureBox1.Image = imagemRotacionada;
            }

        }


        private Image rotacionarImagem(Image imagem)
        {
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

        private bool buscarUsuario(string sugestaoUsuario)
        {
            var usuario = ctx.Usuario.FirstOrDefault(x => x.Usuario1 == sugestaoUsuario);

            return usuario != null;
        }


        private string gerarUsuario(string fullname, string birthDate)
        {
            string[] partName = fullname.Split(' ');

            if(partName.Length < 2)
            {
                MessageBox.Show("O nome deve conter ao menos um sobrenome");
                return null;
            }

            string firstName = partName[0];
            string lastName = partName[partName.Length - 1];

            string lastNumbersDate = birthDate.Substring(birthDate.Length - 2);


            string sugestaoUsuario = $"{firstName}.{lastName}{lastNumbersDate}";
            if (buscarUsuario(sugestaoUsuario))
            {

                sugestaoUsuario = $"{firstName}.{partName.Length - 2}{lastNumbersDate}";

                if (buscarUsuario(sugestaoUsuario))
                {
                    return null;
                }
            }

            return sugestaoUsuario;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fullName = Txt_Name.Text.Trim().ToLower();
            string birthData = dateTimePicker1.Text.Trim();


            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(birthData))
            {
                MessageBox.Show("Preencha os campos nome e data corretamente");
                return;
            }

            string sugestaoUsuario = gerarUsuario(fullName, birthData);

            if (sugestaoUsuario != null)
            {
                Txt_Usuario.Text = sugestaoUsuario;
            }
            else
            {
                MessageBox.Show("Não foi possível gerar aleatório");

            }
        }
    }
}
