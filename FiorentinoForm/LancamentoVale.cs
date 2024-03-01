using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class LancamentoVale : FiorentinoForm.parent
    {
        public LancamentoVale()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LancamentoVale_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctx.People.ToList().Select(x => new
            {
                Id = x.ID,
                Funcionario = x.Name,
                Solicitado = "Sim",
                Valor = x.Discounts.FirstOrDefault().Amount,
                Data_Solicitacao = x.BirthDay,

            }).ToList();

            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.HeaderText = item.Name.Replace("_", " ");
            }


            dataGridView1.Columns[0].Visible = false;

            var btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Ações";
            btn.Text = "Exluir";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

        }
    }
}

