using FiorentionoDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class RankingForm : FiorentionoDesktop.parent
    {
        DataTable dt = new DataTable();
        List<Ranking> ListaRanking = new List<Ranking>();
      
        public RankingForm()
        {
            InitializeComponent();
            //dt.Columns.Add("Bandeira", typeof(Image));
            dt.Columns.Add("Equipe");
            dt.Columns.Add("Pts");
            dt.Columns.Add("PJ");
            dt.Columns.Add("VIT");
            dt.Columns.Add("E");
            dt.Columns.Add("DER");
            dt.Columns.Add("GP");
            dt.Columns.Add("GC");
            dt.Columns.Add("SG");
            //dt.Columns.Add("Últimas 3");


        }

        private void RankingForm_Load(object sender, EventArgs e)
        {
            LoadAnos();
            LoadRanking();
        }

        private void LoadAnos()
        {
            comboBox1.Items.AddRange(ctx.Competicao.Select(x => x.Ano.ToString()).ToArray());
           comboBox1.SelectedIndex = 1;

        }
      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRanking();
        }
        private void LoadRanking()
        {

            var ranking = ctx.Jogos
                .Where(j => j.Competicao.Ano.ToString() == comboBox1.SelectedItem.ToString())
                .GroupBy(j => j.Selecao1)
                .Select(g => new Ranking
                {
                    Nome = g.FirstOrDefault().Selecao.Nome,
                    Bandeira = g.FirstOrDefault().Selecao.Bandeira,
                    Pontos = g.Sum(j => (j.Placar1 > j.Placar2 ? 3 : (j.Placar1 == j.Placar2 ? 1 : 0))),
                    PartidasJogadas = g.Count(),
                    Vitorias = g.Count(j => j.Placar1 > j.Placar2),
                    Empates = g.Count(j => j.Placar1 == j.Placar2),
                    Derrotas = g.Count(j => j.Placar1 < j.Placar2),
                    GolsPro = g.Sum(j => j.Placar1 ?? 0),
                    GolsContra = g.Sum(j => j.Placar2 ?? 0),
                    SaldoGols = g.Sum(j => j.Placar1 ?? 0 - j.Placar2 ?? 0)
                })
                .OrderByDescending(e => e.Pontos)
                .ThenByDescending(e => e.SaldoGols)
                .ToList();

            dt.Clear();

            foreach (var item in ranking)
            {

                Image imagem;
                if (item.Bandeira != null)
                {
                var stream = new MemoryStream(item.Bandeira);
                    imagem = Image.FromStream(stream); 
                }
                else
                {
                    imagem = null;
                }
           
             

                

                dt.Rows.Add(item.Nome, item.Pontos, item.PartidasJogadas, item.Vitorias, item.Empates, item.Derrotas, item.GolsPro, item.GolsContra, item.SaldoGols);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Equipe"].HeaderText = "Equipe";
            dataGridView1.Columns["Pts"].HeaderText = "Pts";
            dataGridView1.Columns["PJ"].HeaderText = "PJ";
            dataGridView1.Columns["Vit"].HeaderText = "VIT";
            dataGridView1.Columns["E"].HeaderText = "E";
            dataGridView1.Columns["DER"].HeaderText = "DER";
            dataGridView1.Columns["GP"].HeaderText = "GP";
            dataGridView1.Columns["GC"].HeaderText = "GC";
            dataGridView1.Columns["SG"].HeaderText = "SG";

            //dataGridView1.Columns["Bandeira"].DefaultCellStyle.NullValue = null;
            //dataGridView1.Columns["Bandeira"].Width = 30;
            //dataGridView1.RowTemplate.Height = 30;

        }






        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new JogosForm().Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            new MeusConvidadosForm().Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new NotificationForm().Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SettingsForm().Show();
            this.Hide();
        }
    }
}
