using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SelectColor : WindowsFormsApp1.parent
    {
        public SelectColor()
        {
            InitializeComponent();
        }

        private void SelectColor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Focused)
            {
                if (textBox1.Text == "")
                {
                    textBox2.Text = "";
                    return;
                }
            }
            hex = ColorTranslator.FromHtml(textBox1.Text);
            textBox2.Text = $"rgb({hex.R},{hex.G},{hex.B})";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Focused)
            {
                if (textBox2.Text == "")
                {
                    textBox1.Text = "";
                    return;
                }

           string texto =     textBox2.Text.Replace("rgb(", "");
                texto = textBox2.Text.Replace(")", "");

                string[] cores = texto.Split(',');

                hex = Color.FromArgb(Convert.ToInt32(cores[0]), Convert.ToInt32(cores[1]), Convert.ToInt32(cores[2]));
                textBox1.Text = hex.Name;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = hex;
            string path = "C:\\colors";
            string file = path + $"\\{logado.Codigo}.txt";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            File.WriteAllText(file, $"#{hex.Name}");

            this.Close();
            new MainPage().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                hex = Color.FromArgb(cd.Color.R, cd.Color.G, cd.Color.B);
                panel1.BackColor = hex;
                textBox1.Text = "#" + hex.Name;
                textBox2.Text = $"rgb({hex.R},{hex.G},{hex.B})";
            }
        }
    }
}
