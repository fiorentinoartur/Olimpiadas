using desktop2020.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop2020.Components
{
    public partial class NotifyControl : UserControl
    {
        public Notificacoes Item { get; }
        public NotifyControl()
        {
            InitializeComponent();
         
        }
        Sessao5Entities ctx = new Sessao5Entities();
        public NotifyControl(Notificacoes item)
        {
            InitializeComponent();
            Item = item;
            if (item.DataHoraEnvio.Value <= DateTime.Now)
            {
                label4.Visible = label5.Visible = false;
            }
        }
        private void NotifyControl_Load(object sender, EventArgs e)
        {
            PutStyle();
            label1.Text = Item.Titulo.ToString();
            label2.Text = Item.Descricao.ToString();    
            label2.AutoEllipsis = true;
            label3.Text = Item.DataHoraEnvio.Value.ToString("dd/MM/yyyy hh:mm");

            if(Item.DataHoraEnvio.Value < DateTime.Now)
            {
                this.BackColor = Color.Orange;
            }
            else if (Item.DataHoraEnvio.Value > DateTime.Now && Item.DataHoraEnvio.Value.Date == DateTime.Now.Date && Item.Importancia == "Padrão")
            {
                this.BackColor = Color.Blue;
            }
            else if(Item.DataHoraEnvio.Value > DateTime.Now && Item.DataHoraEnvio.Value.Date == DateTime.Now.Date && Item.Importancia == "Urgente")
            {
                this.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = Color.Green;
            }

        }
        private void PutStyle()
        {
            foreach(Control control in Controls)
            {
                if(control is Label lb)
                {
                    lb.ForeColor = Color.White;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if ("Deseja exluir".Confirmation() != DialogResult.Yes)
                return;

            ctx.Notificacoes.Remove(ctx.Notificacoes.Find(Item.Id));
            ctx.SaveChanges();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (Item.DataHoraEnvio.Value <= DateTime.Now) return;

            new InsertNotificationForm(Item).ShowDialog();
        }
    }
}
