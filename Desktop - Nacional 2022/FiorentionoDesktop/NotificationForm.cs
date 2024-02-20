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
            dt.Columns.Add("Id");
        }


      

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            LoadNotificacoes();
        }

        private void LoadNotificacoes()
        {
            var nots = ctx.Notificacao.Where(x => x.idusuario == logado.IdUsuario).OrderByDescending(x => x.dataHora).ToList();

            foreach (var item in nots)
            {
                dt.Rows.Add(item.dataHora.ToShortDateString(), item.dataHora.ToShortTimeString(), item.Usuarios.Email, item.notificacao1, item.status,item.id);
            }

            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "p")
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                var not = ctx.Notificacao.Find(id);
                not.status = "l";
                dataGridView1.Rows[e.RowIndex].Cells["Status"].Value = "l";
                ctx.Entry(not).CurrentValues.SetValues(not);
                ctx.SaveChanges();
            }
        }
    }
}
