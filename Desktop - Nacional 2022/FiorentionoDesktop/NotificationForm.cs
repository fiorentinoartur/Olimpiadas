using FiorentionoDesktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class NotificationForm : FiorentionoDesktop.parent
    {
        DataTable dt = new DataTable();

        public NotificationForm()
        {
            InitializeComponent();
            dt.Columns.Add("Data");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Remetente");
            dt.Columns.Add("Notificação");
            dt.Columns.Add("Status");
        }


        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new JogosForm().Show();
            this.Hide();

        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RankingForm().Show();
            this.Hide();

        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SettingsForm().Show();
            this.Hide();

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new MeusConvidadosForm().Show();
            this.Hide();

        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            LoadNotificacoes();
        }

        private void LoadNotificacoes()
        {
            var notificacoes = ctx.Notificacao
           .Where(x => x.idusuario == logado.IdUsuario)
           .ToList()
           .Select(x => new NotificacaoModel
           {
               data = x.dataHora.ToShortDateString(),
               hora = x.dataHora.ToShortTimeString(),
               status = x.status.ToLower() == "p" ? "Pendente" : "Lido",
               User = x.Usuarios.Email,
               notificacao1 = x.notificacao1,
           })
           .ToList();

            foreach (var item in notificacoes)
            {
                dt.Rows.Add(item.data, item.hora, item.User, item.notificacao1, item.status);
            }

            dataGridView1.DataSource = dt;

        }
    }
}
