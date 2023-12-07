using Desktop.Components;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var lista = ctx.Pessoa.ToList();

            foreach (var pessoa in lista)
            {
                dt.Rows.Add(pessoa.Nome, pessoa.CPF, pessoa.Sexo, pessoa.Telefone, Math.Truncate(DateTime.Now.Subtract(pessoa.DataNascimento.Value).TotalDays / 365));
                UserControl1 p = new UserControl1(pessoa);

                flowLayoutPanel1.Controls.Add(p);
            }
            //Configuração
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            //Configuração do FlowLayout
            flowLayoutPanel1.AutoScroll = true;
        }
    }
}
