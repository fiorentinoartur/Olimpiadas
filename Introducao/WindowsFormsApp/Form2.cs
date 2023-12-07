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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ModuloDesktopEntities ctx = new ModuloDesktopEntities();
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (Txt_Email.Text == "" || Txt_Senha.Text == "" || Txt_Apelido.Text == "" || Txt_Time.Text == "" || Txt_Cor.Text == "")
            {
                MessageBox.Show("Preencha todos os campos corretamente");
                return;
            }
            Usuarios user = new Usuarios(); 

            user.email = Txt_Email.Text;
            user.senha = Txt_Senha.Text;
            user.apelido = Txt_Apelido.Text;
            user.timeFavorito = Txt_Time.Text;
            user.corFavorita = Txt_Cor.Text;
            user.nascimento = dateTimePicker1.Value;

            if(pictureBox1.Image != null) 
            { 
            ImageConverter cvt = new ImageConverter();
                byte[] binaryImage = (byte[])cvt.ConvertTo(pictureBox1.Image, typeof(byte[]));
                user.foto = binaryImage;
            
            }

           ctx.Usuarios.Add(user);
            ctx.SaveChanges();
            MessageBox.Show("Usuário cadastrado com sucesso");

        }

        private void btn_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png;*) | *.jpg;*.jpeg;*.png;*";
            ofd.Title = "Imagem selecionada";


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = ofd.FileName;

                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form1().ShowDialog();
        }
    }
}
