using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : parent
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
            panel1.BackColor = Color.White;
            textBox1.Text = "artur.kennez24";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Images | *.png; *.jpg;*.jpeg;*";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opd.FileName);
            }
        }

        private byte[] ConverterImage()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.ToArray();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Cadastro().ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = ctx.Usuario.Where(x => x.Email == textBox1.Text || x.Usuario1 == textBox1.Text).FirstOrDefault();
            if (user == null)
            {
                "Imagem ou usário não reconhecido".Alert();
                SystemSounds.Beep.Play();
                return;
            }
            bool comparado = Enumerable.SequenceEqual(ConverterImage(), user.Foto);
            string path = "C:\\USER_LOGS";
            string file = path + $"\\{user.Nome.Split(' ')[0]}{user.Codigo}.txt";

            if (!comparado)
            {
                var ip = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if(!File.Exists(file))
                {
                    File.WriteAllText(file, $"Data;Hora;Usuario;Ip\n{DateTime.Now.ToShortDateString()};{DateTime.Now.ToShortTimeString()};{user.Usuario1},{ip}");
                }
                else
                {
                    string text = " ";
                    text = File.ReadAllText(file);
                    File.WriteAllText(file, text + $"\n{DateTime.Now.ToShortDateString()};{DateTime.Now.ToShortTimeString()};{user.Usuario1},{ip}");
                       
                }

                "Imagem ou usuário não reconhecido".Alert();
                SystemSounds.Beep.Play ();
                return;
            }
            logado = user;
            new MainPage().Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsKeyLocked(Keys.CapsLock))
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
        }
    }
}
