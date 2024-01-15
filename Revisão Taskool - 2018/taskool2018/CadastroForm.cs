using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using taskool2018.Modal;

namespace taskool2018
{
    public partial class CadastroForm : parent
    {
        public CadastroForm()
        {
            InitializeComponent();
            AplicarBorda(); 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ColocarBorda (Control panel, Control input)
        {
            input.Enter += (object sender, EventArgs e) => panel.BackColor = Color.Blue;
            input.Leave += (object sender, EventArgs e) => panel.BackColor = Color.Transparent;
        }
        private void AplicarBorda()
        {
            ColocarBorda(panel3, Txt_Nome);
            ColocarBorda(panel4, Txt_Email);
            ColocarBorda(panel5, Txt_Telefone);
            ColocarBorda(panel6, Txt_Usuario);
   
        }
        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Email.Text) || string.IsNullOrEmpty(Txt_Nome.Text) || string.IsNullOrEmpty(Txt_Telefone.Text) || string.IsNullOrEmpty(Txt_Usuario.Text))
            {
                "Preencha todos os campos corretamente".Alert();
                return;
            }

            var emailBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == Txt_Email.Text);

            if (emailBuscado != null)
            {
                "Email já cadastrado!!!".Alert();
                return;
            }
            if (!validarEmail(Txt_Email.Text))
            {
                "Email inválido, não segue o padrão da indústria! Ex:user@gmail.com".Alert();
                return;
            }
            if (!vaildarTelefone(Txt_Telefone.Text.Trim()))
            {
                "Telefone deve conter apenas dígitos sem espaços".Alert();
                return;
            }


            Usuario user = new Usuario();
            user.Nome = Txt_Nome.Text;
            user.Email = Txt_Email.Text;
            user.Telefone = Txt_Telefone.Text;
            user.Usuario1 = Txt_Usuario.Text;

            if (pictureBox1.Image != null)
            {
                var stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                user.Foto = stream.ToArray();
            }
            ctx.Usuario.Add(user);
            ctx.SaveChanges();  

            "Usuário cadastrado com sucesso!".Information();
            Txt_Email.Text = "";
            Txt_Nome.Text = "";
            Txt_Telefone.Text = "";
            Txt_Usuario.Text = "";
          //  pictureBox1.Image = Image.FromFile(semFoto);


            new Form1().Show();

            this.Hide();
        }
        private bool vaildarTelefone(string telefone)
        {
            return telefone.All(char.IsDigit);
        }
        private bool validarEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.+[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private void CadastroForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Selecionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens | *.png;*.jpg;*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = Txt_Nome.Text.ToLower().Trim();
            string birthDate = dateTimePicker1.Text.Trim();
            if(string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(birthDate)) 
            { 
            "Os campos Nome e data de nascimento devem ser preenchidos corretamente!".Alert();
             return;
            }

            string sugestaoUsuario = GerarUserAleatorio(fullName, birthDate);
            if (sugestaoUsuario != null)
            {
                "User gerado com sucesso".Information();
                Txt_Usuario.Text = sugestaoUsuario;
            }
            else
            {
                "Não foi possível gera Aleatório".Information();
            }



        }

        private string GerarUserAleatorio(string fullName, string birthDate)
        {
            string[] partName = fullName.Split(' ');
            if(partName.Length < 2 )
            {
                "Usuário deve te ao menos um sobrenome".Alert();
                return null;
            }
            string firstName = partName[0];
            string lastName = partName[partName.Length - 1];
            string ultimosDigitosBirth = birthDate.Substring(birthDate.Length - 2);

            string sugestaoUsuario = $"{firstName}.{lastName}{ultimosDigitosBirth}";

            if(buscarUsuario(sugestaoUsuario))
            {
                string sugestaoUsuaio = $"{firstName}.{partName[partName.Length - 2]}{ultimosDigitosBirth}";

                if (buscarUsuario(sugestaoUsuario))
                {
                    return null;
                }
            }





            return sugestaoUsuario;
        }
        private bool buscarUsuario(string sugestaoUsuario)
        {
           var user = ctx.Usuario.FirstOrDefault(x => x.Usuario1 == Txt_Usuario.Text);

            return user != null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
