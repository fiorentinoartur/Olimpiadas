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

namespace taskool2018
{
    public partial class Form1 : parent
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CadastroForm().Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("osk.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = ctx.Usuario.FirstOrDefault(x => x.Usuario1 == Txt_Usuario.Text);

            if (user == null) 
            {
                "Usuário não encontrado".Alert();
                return;
            }
            var fotoBanco = user.Foto;
            var fotoForm = converterImage(pictureBox1.Image);

          

            if (CompararImagens(fotoForm, fotoBanco))
            {
                $"Seja Bem-Vindo {user.Usuario1}".Information();
                new PrincipalPageForm(user.Codigo) .Show(); 

            }
            else
            {
                $"Não foi possível realizar a autenticação, verifique todos os dados!".Alert();
                return;
            }

        }

        private byte[] converterImage(Image image)
        {
            var stream = new MemoryStream();

            image.Save(stream, image.RawFormat);

            return stream.ToArray();
        }
        private bool CompararImagens(byte[] image1 , byte[] image2)
        {
            return image1.SequenceEqual(image2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens | *.png;*.jpg*.jpeg;*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
