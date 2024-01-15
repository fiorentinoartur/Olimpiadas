using desktop2020.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace desktop2020
{
    public partial class JogadoresForm : desktop2020.parent
    {
        public JogadoresForm()
        {
            InitializeComponent();
        }
        public Selecoes Selecao { get; set; }
        public JogadoresForm(Selecoes seleco)
        {
            InitializeComponent();
            Selecao = seleco;
            label1.Text = seleco.Nome.ToString();
            dataGridView1.DataSource = seleco.Jogadores.ToString();
        }
        private void JogadoresForm_Load(object sender, EventArgs e)
        {

        }
    }
}
