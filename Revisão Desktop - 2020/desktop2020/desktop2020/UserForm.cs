using desktop2020.Properties;
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
    public partial class UserForm : desktop2020.parent
    {
        DataTable dt = new DataTable();
        Settings settings = new Settings();
        public UserForm()
        {
            InitializeComponent();
            dt.Columns.Add("Id");
            dt.Columns.Add("Mandante");
            dt.Columns.Add("Placar");
            dt.Columns.Add(" ");
            dt.Columns.Add("Placar ");
            dt.Columns.Add("Visitante");
            dt.Columns.Add("  ");
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if(Dados.Logged.Foto != null)
            {
                pictureBox1.Image = Image.FromStream(new MemoryStream(Dados.Logged.Foto));
            }
            if(Dados.Logged.NotificacoesUsuarios.Where(x => x.Status == "Pendente").Count() > 0) 
            {
                pictureBox3.Image = Properties.Resources.notification;
            }
            LoadGames();

        }

        private void LoadGames()
        {
            dt.Rows.Clear();

            var rodada = ctx.Rodadas.ToList().OrderBy(x => x.DataInicio).Last();
            foreach (var item in rodada.Jogos)
            {
                dt.Rows.Add(item.Id, item.Selecoes.Nome, item.PlacarCasa, "X", item.PlacarVisitante, item.Selecoes1.Nome, "Comentar");
            }
            dataGridView1.DataSource = dt;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new NotifyForm().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 1)
            {
                var selecao = ctx.Selecoes.ToList().First(x => x.Nome == dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                new JogadoresForm(selecao).Show();
            }
            if(e.ColumnIndex == 5)
            {
                var selecao = ctx.Selecoes.ToList().First(x => x.Nome == dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                new JogadoresForm(selecao).Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LoginForm().Show();
            settings.keep = false;
            this.Close();
        }
    }
}
