using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class FrequenciaFunc : FiorentinoForm.parent
    {
        List<objFrequencia> dados;
        public FrequenciaFunc()
        {
            InitializeComponent();
        }
        int iMes = 1;


        static string getFullName(int month, int ano)
        {
            DateTime date = new DateTime(ano, month, 1);

            return date.ToString("MMMM");
        }
        private void FrequenciaFunc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            int ano = DateTime.Now.Year;
            int mes = iMes;
            int diasNoMes = DateTime.DaysInMonth(ano, mes);


            labelMes.Text = $"{getFullName(mes, ano)} 2024";

            var frequencias = ctx.Frequencies.Where(x => x.Date.Value.Month == mes).ToList();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dados = frequencias
                .GroupBy(f => f.Employees.People.Name)
                .Select(g => new objFrequencia
                {

                    Funcionario = g.FirstOrDefault().Employees.People.Name,
                    Dia = Enumerable.Range(1, 30)
                            .Select(day => g.Any(f => f.Date.Value.Day == day) ? g.First(f => f.Date.Value.Day == day).Attachment : "-").ToList(),
                    Presenca = g.Count(x => x.Attachment == "P"),
                    Falta = g.Count(x => x.Attachment == "F"),
                    Atestado = g.Count(x => x.Attachment == "A")
                }).ToList();

            dataGridView1.Columns.Add("Funcionário", "Funcionário");
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName == "Funcionário")
                    column.Width = 100;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            for (int i = 1; i <= diasNoMes; i++)
            {
                var valor = i.ToString();
                if (int.Parse(valor) < 10)
                {
                    valor = "0" + valor;
                }
                List<DateTime> feriados = new List<DateTime>
                {
                    new DateTime(ano,1,1),
                    new DateTime(ano,2,12),
                    new DateTime(ano,2,13),
                    new DateTime(ano,3,29),
                    new DateTime(ano,3,21),
                    new DateTime(ano,5,1),
                    new DateTime(ano,5,30),
                    new DateTime(ano,9,7),
                    new DateTime(ano,10,12),
                    new DateTime(ano,11,02),
                    new DateTime(ano,11,15),
                    new DateTime(ano,11,20),
                    new DateTime(ano,12,25)

                };
                var column = dataGridView1.Columns.Add("Dias", valor);
                if (new DateTime(ano, mes, i).DayOfWeek == DayOfWeek.Sunday || ctx.Holydays.Select(x => x.Date).ToList().Contains(new DateTime(ano, mes, i)))
                {
                    dataGridView1.Columns[column].DefaultCellStyle.BackColor = Color.Orange;
                }
            }


            var columnPresenca = dataGridView1.Columns.Add("Presencas", "Presencas");
            var columnFalta = dataGridView1.Columns.Add("Faltas", "Faltas");
            var columnAtestado = dataGridView1.Columns.Add("Atestados", "Atestados");


            foreach (var item in dados)
            {
                var rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.Funcionario;
                dataGridView1.Rows[rowIndex].Cells[columnPresenca].Value = item.Presenca;
                dataGridView1.Rows[rowIndex].Cells[columnFalta].Value = item.Falta;
                dataGridView1.Rows[rowIndex].Cells[columnAtestado].Value = item.Atestado;
                for (int i = 1; i < item.Dia.Count; i++)
                {
                    if (i + 1 < dataGridView1.Columns.Count)
                    {
                        dataGridView1.Rows[rowIndex].Cells[i + 1].Value = item.Dia[i];

                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ano = DateTime.Now.Year;
            int mes = iMes;
            int diasMes = DateTime.DaysInMonth(ano, mes);
            var ofd = new SaveFileDialog();
            ofd.Filter = "CSV File | *.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var csvContent = new StringBuilder();


                csvContent.Append("Funcionários;");
                for (int i = 0; i <= 30; i++)
                {
                    csvContent.Append($"{i};");
                }
                csvContent.AppendLine("Presencas;Atestados;Faltas");

                foreach (var item in dados)
                {

                    csvContent.Append($"{item.Funcionario};");
                    for (int i = 0; i <= diasMes; i++)
                    {

                        string diaValue = "-";
                        if (i < item.Dia.Count)
                        {
                            diaValue = item.Dia[i];
                        }
                        csvContent.Append($"{diaValue};");

                    }
                    csvContent.AppendLine($"{item.Presenca};{item.Atestado};{item.Falta}");
                }

                File.WriteAllText(ofd.FileName, csvContent.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (iMes < 2)
            {
                MessageBox.Show("Não há dados para mostrar");
                return;
            }
            iMes--;
            LoadData();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (iMes > 11)
            {
                MessageBox.Show("Não há dados para mostrar");
                return;
            }
            iMes++;
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                LoadData();
                return;
            }

            int ano = DateTime.Now.Year;
            int mes = iMes;
            int diasNoMes = DateTime.DaysInMonth(ano, mes);


            labelMes.Text = $"{getFullName(mes, ano)} 2024";

            var frequencias = ctx.Frequencies.Where(x => x.Employees.People.Name.Contains(textBox1.Text)).ToList();

            
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dados = frequencias
                .GroupBy(f => f.Employees.People.Name)
                .Select(g => new objFrequencia
                {
                    Funcionario = g.Key,
                    Dia = Enumerable.Range(1, 30)
                            .Select(day => g.Any(f => f.Date.Value.Day == day) ? g.First(f => f.Date.Value.Day == day).Attachment : "-").ToList(),
                    Presenca = g.Count(x => x.Attachment == "P"),
                    Falta = g.Count(x => x.Attachment == "F"),
                    Atestado = g.Count(x => x.Attachment == "A")
                }).ToList();

 

            dataGridView1.Columns.Add("Funcionário", "Funcionário");

            for (int i = 1; i <= diasNoMes; i++)
            {
                var valor = i.ToString();
                if (int.Parse(valor) < 10)
                {
                    valor = "0" + valor;
                }
                List<DateTime> feriados = new List<DateTime>
                {
                    new DateTime(ano,1,1),
                    new DateTime(ano,2,12),
                    new DateTime(ano,2,13),
                    new DateTime(ano,3,29),
                    new DateTime(ano,3,21),
                    new DateTime(ano,5,1),
                    new DateTime(ano,5,30),
                    new DateTime(ano,9,7),
                    new DateTime(ano,10,12),
                    new DateTime(ano,11,02),
                    new DateTime(ano,11,15),
                    new DateTime(ano,11,20),
                    new DateTime(ano,12,25)

                };
                var column = dataGridView1.Columns.Add("Dias", valor);
                if (new DateTime(ano, mes, i).DayOfWeek == DayOfWeek.Sunday || feriados.Contains(new DateTime(ano, mes, i)))
                {
                    dataGridView1.Columns[column].DefaultCellStyle.BackColor = Color.Orange;
                }
            }


            var columnPresenca = dataGridView1.Columns.Add("Presencas", "Presencas");
            var columnFalta = dataGridView1.Columns.Add("Faltas", "Faltas");
            var columnAtestado = dataGridView1.Columns.Add("Atestados", "Atestados");


            foreach (var item in dados)
            {
                var rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.Funcionario;
                dataGridView1.Rows[rowIndex].Cells[columnPresenca].Value = item.Presenca;
                dataGridView1.Rows[rowIndex].Cells[columnFalta].Value = item.Falta;
                dataGridView1.Rows[rowIndex].Cells[columnAtestado].Value = item.Atestado;
                for (int i = 1; i < item.Dia.Count; i++)
                {
                    if (i + 1 < dataGridView1.Columns.Count)
                    {
                        dataGridView1.Rows[rowIndex].Cells[i + 1].Value = item.Dia[i];

                    }
                }
            }

        }
    }

        internal class objFrequencia
        {


            public string Funcionario { get; set; }
            public List<string> Dia { get; set; }
            public int Presenca { get; set; }
            public int Falta { get; set; }
            public int Atestado { get; set; }
        }
    }


