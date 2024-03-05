using FiorentinoForm;
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


            comboBox1.Items.AddRange(ctx.Benefits.Select(x => x.Name).ToArray());


            LoadData();

        }
        private void filtrar()
        {
        var lista =   ctx.PersonBenefits.Where(x =>
            (textBox1.Text == " " || x.People.Name.ToLower().Contains(textBox1.Text) && 
            (comboBox1.SelectedIndex < 0 || comboBox1.SelectedItem == x.Benefits.Name) &&
            (x.SolicitationDate >= dateTimePicker1.Value && x.SolicitationDate <= dateTimePicker2.Value)
            )).ToList(); 

     

            dataGridView1.DataSource = lista.Select(x => new
            {
                Id = x.ID,
                Funcionario = x.People.Name,
                Vale = x.Benefits.Name,
                Valor = x.Amount.ToString(),
                Data_Solicitacao = x.SolicitationDate,
                Data_Cancelamento = x.CancelationDate ?? "-",
                Ocorrencia = x.Occurrence.Value == 0 ? "Dia" : "Mês"
            }).ToList();
        }


        private void LoadData()
        {
            dataGridView1.DataSource = ctx.PersonBenefits.ToList().Select(x => new
            {
                Id = x.ID,
                Funcionario = x.People.Name,
                Vale = x.Benefits.Name,
                Valor = x.Amount.ToString(),
                Data_Solicitacao = x.SolicitationDate,
                Data_Cancelamento = x.CancelationDate ?? "-",
                Ocorrencia = x.Occurrence.Value == 0 ? "Dia" : "Mês"
            }).ToList();


            dataGridView1.Columns[0].Visible = false;
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.HeaderText = item.Name.Replace("_", " ");
            }

            var btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Ações";
            btn.Text = "Cancelar";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new CadastroValeForm().ShowDialog();
            Close();
        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                int idCell = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                var personBenefit = ctx.PersonBenefits.Find(idCell);

                personBenefit.CancelationDate = DateTime.Now.ToShortDateString();

                ctx.Entry(personBenefit).CurrentValues.SetValues(personBenefit);
                ctx.SaveChanges();
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Você deve selecionar apenas uma coluna");
                return;
            }

            int id = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value.ToString());   
            var personBenefit = ctx.PersonBenefits.Find(id);

            Hide();
            new CadastroValeForm(personBenefit).ShowDialog();
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}



