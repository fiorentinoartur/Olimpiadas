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

        private void FrequenciaFunc_Load(object sender, EventArgs e)
        {

            var frequencias = ctx.Frequencies.ToList();

            dados = frequencias
                .GroupBy(f => f.Employees.People.Name)
                .Select(g => new objFrequencia
                {
                    Funcionario = g.Key, // Aqui você pode usar g.Key para obter o nome do funcionário
                    Dia = Enumerable.Range(1, 30)
                            .Select(day => g.Any(f => f.Date.Value.Day == day) ? g.First(f => f.Date.Value.Day == day).Attachment : "-").ToList(),
                    Presenca = g.Count(x => x.Attachment == "P"),
                    Falta = g.Count(x => x.Attachment == "F"),
                    Atestado = g.Count(x => x.Attachment == "A")
                }).ToList();

            dataGridView1.Columns.Add("Funcionário", "Funcionário");
            //// Adicione as colunas para o DataGridView
            for (int i = 1; i <= 30; i++)
            {
                var valor = i.ToString();
                if (int.Parse(valor) < 10)
                {
                    valor = "0" + valor;
                }
                dataGridView1.Columns.Add("Dias", valor);
            }

            dataGridView1.Columns.Add("Presencas", "Presencas");
            dataGridView1.Columns.Add("Faltas", "Faltas");
            dataGridView1.Columns.Add("Atestados", "Atestados");

            foreach (var item in dados)
            {
                var rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = item.Funcionario;
                dataGridView1.Rows[rowIndex].Cells[31].Value = item.Presenca;
                dataGridView1.Rows[rowIndex].Cells[32].Value = item.Falta;
                dataGridView1.Rows[rowIndex].Cells[33].Value = item.Atestado;
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
                    for (int i = 0; i <= 30; i++)
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

