using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Cadastro : WindowsFormsApp1.parent
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            GraphicsPath ellipsePath = new GraphicsPath();  
            ellipsePath.AddEllipse(0,0,pictureBox1.Width - 1, pictureBox1.Height - 1);

            pictureBox1.Region = new Region(ellipsePath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text)) 
            { 
            "Todos os campos s]ao obrigatórios".Alert();
                return;
            }
            if(!textBox2.Text.Contains("@") || textBox2.Text.Length < 2)
            {
                "O email não segue o padrão da indústria".Alert();
                return;
            }
            Usuario user = new Usuario();
            user.Nome = textBox1.Text;
            user.Email = textBox2.Text;
            user.Telefone = textBox3.Text;
            user.Usuario1 = textBox4.Text;
           

            var ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            user.Foto = ms.ToArray();
            ctx.Usuario.Add(user);
            ctx.SaveChanges();
            "Usuário Cadastrado com sucesso".Information();
            this.Close();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                "Nome e nascimento devem ser preenchidos corretamente!".Alert();
                return;
            }
            string[] nomes = textBox1.Text.Split(' ');
            string apelido = $"{nomes[0]}.{nomes[nomes.Length - 1]}{dateTimePicker1.Value.Year.ToString().Substring(2,2)}";

            if(ctx.Usuario.Where(x => x.Usuario1 == apelido).FirstOrDefault() != null) 
            { 
            if(nomes.Length > 2)
                {
                    apelido = $"{nomes[0]}.{nomes[nomes.Length - 2]}";
                    if(ctx.Usuario.Where(x => x.Usuario1 == apelido).FirstOrDefault() != null)
                    {
                        "Não foi possível gerar aleatório".Alert();
                    }
                }
                else
                {
                    "Não foi possível gerar aleatório".Alert();
                return;
                }
            }
            var noAceent = Encoding.GetEncoding("ISO-8859-8").GetBytes(apelido);
            apelido = Encoding.UTF8.GetString(noAceent);
            textBox4.Text = apelido.ToLower();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images | *.png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
