using DesktopPR.Models;
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

namespace DesktopPR.Components
{
    public partial class PessoaControl : UserControl
    {
        public PessoaControl()
        {
            InitializeComponent();
        }

        public PessoaControl(Pessoa pessoa)
        {

            InitializeComponent();
            Pessoa = pessoa;
            // Rotação da imagem
            Image imagemRotacionada = RotacionarImagem(Image.FromStream(new MemoryStream(pessoa.Foto)));

            pictureBox1.Image = imagemRotacionada;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            label1.Text = pessoa.Nome;
            label2.Text = pessoa.CPF;
            label3.Text = pessoa.DataNascimento.Value.ToShortDateString();
        }

        public Pessoa Pessoa { get; }

        private Image RotacionarImagem(Image imagem)
        {
            // Verificar a orientação da imagem e rotacionar conforme necessário
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
        private void PessoaControl_Load(object sender, EventArgs e)
        {

        }
    }
}
