using desktop2020.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace desktop2020
{
    public partial class SingUpForm : desktop2020.parent
    {
        public SingUpForm()
        {
            InitializeComponent();
            textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                "All fields are required".Alert();
                return;
            }
            if(textBox2.Text.Length < 4 || !char.IsLetter(textBox2.Text[0])) 
            {
                "The Email must have at least 4 caracters and has to start with a letter".Alert();
                return;
            }

            var user = new Usuarios();
            user.Nome = textBox1.Text;
            user.Email = textBox2.Text;
            user.Senha = "admin123";
            user.Nascimento = dateTimePicker1.Value;

            if(pictureBox1.Image != null ) 
            {
                var ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                user.Foto = ms.ToArray();
            }
            user.Sexo = radioButton1.Checked ? "M" : "F";
            user.perfil = "1";
            ctx.Usuarios.Add(user); 
            ctx.SaveChanges();

            "Succes".Information();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SingUpForm_Load(object sender, EventArgs e)
        {
            textBox2.Leave += TextBox2_Leave;
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            radioButton1.Checked = true;

            comboBox1.Items.AddRange(ctx.Selecoes.Select(x => x.Nome).ToArray());   
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            var email  = ctx.Usuarios.FirstOrDefault(x => x.Email == textBox2.Text);
            if(email != null) 
            {
                textBox3.Visible = true;
            }
            else
            {
                textBox3.Visible= false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens | *.bmp; *.jpg; *.jpeg; *.png;";
            if(ofd.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
