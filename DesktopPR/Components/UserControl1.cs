using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Components
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(Pessoa pessoa)
        {
            InitializeComponent();
            Pessoa = pessoa;

            pictureBox1.Image = Image.FromStream(new MemoryStream(pessoa.Foto));
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            label1.Text = pessoa.Nome;
            label2.Text = pessoa.CPF;
            label3.Text = pessoa.DataNascimento.Value.ToShortDateString();
        }

        public Pessoa Pessoa { get; }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
