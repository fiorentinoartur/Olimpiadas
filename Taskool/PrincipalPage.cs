using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Taskool.Modal;

namespace Taskool
{
    public partial class PrincipalPage : Form
    {
        private int idUsuario;
        //private SoundPlayer soundPlayer;
        private MediaPlayer mediaPlayer;
        private GerenciadorFrases gerenciadorFrases;
        private Random random = new Random();
        private bool estaTocando = false;
        public PrincipalPage(int id)
        {
            this.idUsuario = id;
            InitializeComponent();
            gerenciadorFrases = new GerenciadorFrases();
            edit_Sair.Visible = false;
            InicializarComponentes();
        }

        dbTarefasEntities ctx = new dbTarefasEntities();

        private void InicializarComponentes()
        {

            string caminhoDaPasta = Path.Combine(@"C:\Users\Artur Fiorentino\OneDrive\Área de Trabalho\Taskool\musicas-teste-20231226T134815Z-001\musicas-teste");

            string[] arquivosDeMusicas = Directory.GetFiles(caminhoDaPasta);

            if (arquivosDeMusicas.Length > 0)
            {
                string musicaEscolhida = arquivosDeMusicas[random.Next(arquivosDeMusicas.Length)];
                playMusic.Image = Image.FromFile(@"C:\Users\Artur Fiorentino\OneDrive\Área de Trabalho\Taskool\Icons\play_icon_134504.jpeg");

                mediaPlayer = new MediaPlayer();

                string nomeMusica = Path.GetFileName(musicaEscolhida);

                labelMusica.Text = nomeMusica;

                mediaPlayer.Open(new Uri(musicaEscolhida));

            }
            else
            {
                MessageBox.Show("Nenhuma música encontrada");
            }
        }
        private void playMusic_Click(object sender, EventArgs e)
        {



            if (estaTocando)
            {
                playMusic.Image = Image.FromFile(@"C:\Users\Artur Fiorentino\OneDrive\Área de Trabalho\Taskool\Icons\play_icon_134504.jpeg");
                mediaPlayer.Pause();
            }
            else
            {
                playMusic.Image = Image.FromFile(@"C:\Users\Artur Fiorentino\OneDrive\Área de Trabalho\Taskool\Icons\pausar (2).jpeg");
                mediaPlayer.Play();
            }
            estaTocando = !estaTocando;
        }
        private void PrincipalPage_Load(object sender, EventArgs e)
        {
            GraphicsPath ellipsePath = new GraphicsPath();
            ellipsePath.AddEllipse(0, 0, add_Task.Width - 1, add_Task.Height - 1);

            add_Task.Region = new Region(ellipsePath);



            GraphicsPath elipseImage = new GraphicsPath();
            elipseImage.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);

            pictureBox1.Region = new Region(elipseImage);


            var usuario = ctx.Usuario.FirstOrDefault(x => x.Codigo == idUsuario);
            var stream = new MemoryStream(usuario.Foto);
            pictureBox1.Image = Image.FromStream(stream);




            string saudacao;
            string name = usuario.Nome;
            string[] partName = name.Split(' ');
            string firsName = partName[0];
            DateTime horario = DateTime.Now;
            int hora = horario.Hour;

            if (hora >= 12 && hora < 18)
                saudacao = $"Boa Tarde {firsName}";
            else if (hora >= 18 && hora < 24)
                saudacao = $"Boa Noite {firsName}";
            else if (hora >= 0 && hora < 4)
                saudacao = $"Boa Madrugada {firsName}";
            else
                saudacao = $"Bom dia {firsName}";

            Txt_Saudacao.Text = saudacao;

            string mensagemMotivacional = gerenciadorFrases.ObterFraseAleatoria().Mensagem;
            string autorMotivacional = gerenciadorFrases.ObterFraseAleatoria().Autor;

            Txt_Frase.Text = $"{mensagemMotivacional}";
            Txt_Autor.Text = $"{autorMotivacional}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            edit_Sair.Visible = !edit_Sair.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("HH:mm");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btn_English.BackColor = System.Drawing.Color.FromArgb(77, 149, 213);
            btn_Portuguese.BackColor = System.Drawing.Color.White;

            var usuario = ctx.Usuario.FirstOrDefault(x => x.Codigo == idUsuario);

            string saudacao;
            string name = usuario.Nome;
            string[] partName = name.Split(' ');
            string firsName = partName[0];
            DateTime horario = DateTime.Now;
            int hora = horario.Hour;

            if (hora >= 12 && hora < 18)
                saudacao = $"Good Afternoom {firsName}";
            else if (hora >= 18 && hora < 24)
                saudacao = $"Good Evening {firsName}";
            else if (hora >= 0 && hora < 4)
                saudacao = $"Good sun-up {firsName}";
            else
                saudacao = $"Good Morning {firsName}";


            Txt_Saudacao.Text = saudacao;
        }

        private void btn_Portuguese_Click(object sender, EventArgs e)
        {
            var usuario = ctx.Usuario.FirstOrDefault(x => x.Codigo == idUsuario);

            btn_English.BackColor = System.Drawing.Color.White;
            btn_Portuguese.BackColor = System.Drawing.Color.FromArgb(77, 149, 213);

            string saudacao;
            string name = usuario.Nome;
            string[] partName = name.Split(' ');
            string firsName = partName[0];
            DateTime horario = DateTime.Now;
            int hora = horario.Hour;

            if (hora >= 12 && hora < 18)
                saudacao = $"Boa Tarde {firsName}";
            else if (hora >= 18 && hora < 24)
                saudacao = $"Boa Noite {firsName}";
            else if (hora >= 0 && hora < 4)
                saudacao = $"Boa Madrugada {firsName}";
            else
                saudacao = $"Bom dia {firsName}";


            Txt_Saudacao.Text = saudacao;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new Form1().Show();
                Close();  //Fecha a instância atual
            }
        }


    }
}
