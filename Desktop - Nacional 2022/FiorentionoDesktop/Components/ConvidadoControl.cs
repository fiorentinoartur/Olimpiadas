using FiorentionoDesktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentionoDesktop.Components
{
    public partial class ConvidadoControl : UserControl
    {
        private Usuarios item;
        public ConvidadoControl(Usuarios item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void ConvidadoControl_Load(object sender, EventArgs e)
        {
            GraphicsPath ellipse = new GraphicsPath();
            ellipse.AddEllipse(0,0, pictureBox2.Width - 1, pictureBox2.Width - 1);
           pictureBox2.Region = new Region(ellipse);


            if(item.Foto != null)
            {
                MemoryStream ms = new MemoryStream(item.Foto);
                pictureBox2.Image = Image.FromStream(ms);
            }
            label1.Text = item.Email;
            if (item.DataCadastro == null)
            {
                if (item.DataConvite.AddDays(30) < DateTime.Now)
                {
                    label2.Text = "Expirado";
                }
                else
                {
                    label2.Text = "Pendente";
                }
            }
            else
            {
                label2.Text = "Cadastrado";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
