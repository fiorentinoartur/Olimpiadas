using FiorentionoDesktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class PrincipalForm : FiorentionoDesktop.parent
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }      
        public PrincipalForm(Usuarios usuario)
        {
            InitializeComponent();
            logado = usuario;
        }

        
        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void PrincipalForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(logado.Foto != null)
            {
                MemoryStream ms = new MemoryStream(logado.Foto);
                pictureBox1.Image = Image.FromStream(ms);
            }
            if (logado.RecebeNotificacao.Value)
            {
                notifyIcon1.Visible = true;

            }
        }

        private void convidadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MeusConvidadosForm().ShowDialog();
        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new JogosForm().ShowDialog();
        }

        private void rankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RankingForm().ShowDialog();
        }

        private void notificacoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NotificationForm().ShowDialog();
        }

        private void configuracoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            new SingUpForm().ShowDialog();
        }
    }
}
