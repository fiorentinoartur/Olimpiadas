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
    public partial class JogosForm : FiorentionoDesktop.parent
    {
        DataTable dt = new DataTable();
        public JogosForm()
        {
            InitializeComponent();

            dt.Columns.Add("Data");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Time 1");
            dt.Columns.Add("Placa1");
            dt.Columns.Add("X");
            dt.Columns.Add("Placa2");
            dt.Columns.Add("Time 2");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void JogosForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(ctx.Competicao.OrderByDescending(x => x.Ano).Select(x => x.Ano.ToString()).ToArray());
            comboBox1.SelectedIndex = 0;
            ColorDgv();
        }


      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comp = ctx.Competicao.Where(x => x.Ano.ToString() == comboBox1.Text.ToString()).FirstOrDefault();
            label1.Text = $"{comp.Ano}/{comp.Local}";


            var jogos = ctx.Jogos.OrderByDescending(x => x.Data).ToList().Where(x => x.Competicao.Ano.ToString() == comboBox1.SelectedItem.ToString()).ToList();
            dt.Rows.Clear();
            foreach (var item in jogos)
            {
                dt.Rows.Add(item.Data.Value.ToShortDateString(), item.Data.Value.ToShortTimeString(), item.Selecao.Nome, item.Placar1, "X", item.Placar2, item.Selecao3.Nome);
            }
            dataGridView1.DataSource = dt;
        }
        private void ColorDgv()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int placar1 = Convert.ToInt32(row.Cells[3].Value);
                int placar2 = Convert.ToInt32(row.Cells[5].Value);
                if (placar1 > placar2)
                {
                    row.Cells["Time 1"].Style.ForeColor = Color.Blue;
                }
                else if (placar1 < placar2)
                {
                    row.Cells["Time 2"].Style.ForeColor = Color.Blue;
                }
                else
                {
                    row.Cells["Time 1"].Style.BackColor = Color.Yellow;
                    row.Cells["Time 2"].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDgv();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            ColorDgv();
        }
    }
}
