using DesktopPR.Components;
using DesktopPR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopPR
{
    public partial class Form1 : Form
    {
        DesktopPREntities ctx = new DesktopPREntities();
        public Form1()
        {
            InitializeComponent();
            dt.Columns.Add("Nome");
            dt.Columns.Add("CPF");
            dt.Columns.Add("Genero");
            dt.Columns.Add("Telefone");
            dt.Columns.Add("Idade");
        }
        DataTable dt = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
                var lista = ctx.Pessoa.ToList();

            foreach (var pessoa in lista)
            {
                dt.Rows.Add(pessoa.Nome, pessoa.CPF, pessoa.Sexo, pessoa.Telefone, Math.Truncate(DateTime.Now.Subtract(pessoa.DataNascimento.Value).TotalDays / 365));

                PessoaControl p = new PessoaControl(pessoa);

                flowLayoutPanel1.Controls.Add(p);
            }

            //Configuração DataGridView
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            //Confiuração do FlowLayout
            flowLayoutPanel1.AutoScroll = true;
        }
    }
}
