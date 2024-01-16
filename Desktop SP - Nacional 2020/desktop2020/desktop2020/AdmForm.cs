using desktop2020.Components;
using desktop2020.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop2020
{
    public partial class AdmForm : parent
    {
        DataTable dt = new DataTable();

        public Rodadas CurrentRodada { get; set; }
        public AdmForm()
        {
            InitializeComponent();
            dt.Columns.Add("Id");
            dt.Columns.Add("Data");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Mandante");
            dt.Columns.Add("Placar");
            dt.Columns.Add(" ");
            dt.Columns.Add("Placar ");
            dt.Columns.Add("Visitante");
            dt.Columns.Add("");

            CurrentRodada = ctx.Rodadas.First();
        }

        int rodada = 0;

        private void AdmForm_Load(object sender, EventArgs e)
        {
            LoadGames();
            LoadNotify();
            tabControl();
            labelInicio.Text = $"{CurrentRodada.DataInicio.ToShortDateString()}";
            labelTermino.Text = $"{CurrentRodada.DataInicio.AddDays(1).ToShortDateString()}";
        }
        private void LoadGames()
        {
            dt.Rows.Clear();
            TimeSpan horioJogos = new TimeSpan(8, 0, 0);

            var jogos = ctx.Jogos
                .Where(x => x.RodadaId == CurrentRodada.Id)
                .ToList() // Carrega os dados do banco de dados para a memória
                .Select(x => new Jogos
                {
                    Id = x.Id,
                    Data = x.Data + horioJogos.Add(new TimeSpan(2 * ((x.Id - 1) % 4), 0, 0)),
                    SelecaoCasaId = x.SelecaoCasaId,
                    PlacarCasa = x.PlacarCasa,
                    PlacarVisitante = x.PlacarVisitante,
                    SelecaoVisitanteId = x.SelecaoVisitanteId,
                })
                .ToList(); // Converte a consulta para uma lista em memória

            label2.Text = $"Rodada {rodada + 1}";
            foreach (var jogo in jogos)
            {
                dt.Rows.Add(jogo.Id, jogo.Data.Value.ToShortDateString(), jogo.Data.Value.ToShortTimeString(), GetSelecaoNome(jogo.SelecaoCasaId.Value), jogo.PlacarCasa, "X", jogo.PlacarVisitante, GetSelecaoNome(jogo.SelecaoVisitanteId.Value), "Atualizar Placar");
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }

        private void LoadNotify()
        {
            flowLayoutPanel1.Controls.Clear();

            label5.Text = $"{ctx.Notificacoes.Count()} Notificações";
            foreach (var item in ctx.Notificacoes.OrderByDescending(x => x.DataHoraEnvio))
            {
                var c = new NotifyControl(item);
       
                flowLayoutPanel1.Controls.Add(c);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            new InsertNotificationForm().ShowDialog();
            LoadNotify();
        }
        private void tabControl()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                button1.Visible = label5.Visible = false;
            }
            else
                button1.Visible = label5.Visible = true;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }


        // Função para obter o nome da seleção com base no ID
        private string GetSelecaoNome(int selecaoId)
        {
            var selecao = ctx.Selecoes.FirstOrDefault(s => s.Id == selecaoId);
            return selecao != null ? selecao.Nome : "Nome não encontrado";
        }


        private void button1_Click(object sender, EventArgs e)
        {
          
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            rodada--;
            if (rodada == -1)
            {
                rodada = 0;
                "It's the minimum".Alert();



            }
            CurrentRodada = ctx.Rodadas.ToList()[rodada];
            labelInicio.Text = $"{CurrentRodada.DataInicio.ToShortDateString()}";
            labelTermino.Text = $"{CurrentRodada.DataInicio.AddDays(1).ToShortDateString()}";
            LoadGames();
        }

        private void pictureBoxRigth_Click(object sender, EventArgs e)
        {
            rodada++;
            if (rodada == ctx.Rodadas.Count())
            {
                rodada = rodada - 1;
         
                "It's the maximum".Alert();
            }

            CurrentRodada = ctx.Rodadas.ToList()[rodada];
            labelInicio.Text = $"{CurrentRodada.DataInicio.ToShortDateString()}";
            labelTermino.Text = $"{CurrentRodada.DataInicio.AddDays(1).ToShortDateString()}";
            LoadGames();
        }
        private DateTime CriarNovaRodada()
        {
            var rodadas = ctx.Rodadas.ToList();
            DateTime novaRodada = rodadas.OrderByDescending(x => x.DataInicio).Select(x => x.DataInicio).FirstOrDefault().AddDays(7);
            return novaRodada;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DateTime novaRodada = CriarNovaRodada();
            Rodadas novaRodadaBanco = new Rodadas { DataInicio = novaRodada };

            ctx.Rodadas.Add(novaRodadaBanco);
            ctx.SaveChanges();

            var times = ctx.Selecoes.Select(t => t.Id).ToList();

            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                var ids = ctx.Jogos.ToList();
                int id = ids.OrderByDescending(t => t.Id).Select(t => t.Id).FirstOrDefault();

                int timeCasa = random.Next(times.Count);
                int timeVisitante = random.Next(times.Count);

                while (timeCasa == timeVisitante)
                    timeVisitante = random.Next(times.Count);

                var jogo = new Jogos()
                {
                    Id = id + 1,
                    RodadaId = novaRodadaBanco.Id,
                    SelecaoCasaId = times[timeCasa],
                    SelecaoVisitanteId = times[timeVisitante],
                    PlacarCasa = random.Next(0, 5),
                    PlacarVisitante = random.Next(0, 5),
                    Data = i < 4 ? novaRodada : novaRodada.AddDays(1)
                };
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }

            rodada = ctx.Rodadas.ToList().IndexOf(novaRodadaBanco);
            CurrentRodada = novaRodadaBanco;

            labelInicio.Text = $"{CurrentRodada.DataInicio.ToShortDateString()}";
            labelTermino.Text = $"{CurrentRodada.DataInicio.AddDays(1).ToShortDateString()}";
            LoadGames();
        }

    }

}

