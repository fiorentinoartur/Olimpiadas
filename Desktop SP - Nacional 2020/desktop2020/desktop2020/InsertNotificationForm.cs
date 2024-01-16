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

namespace desktop2020
{
    public partial class InsertNotificationForm : parent
    {
        public Notificacoes Item { get; }
        public InsertNotificationForm()
        {
            InitializeComponent();
      
        }
        public InsertNotificationForm(Notificacoes item)
        {
            InitializeComponent();
            Item = item;
            textBox1.Text = item.Titulo;
            textBox2.Text = item.Descricao;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Notificacoes not = new Notificacoes();
            not.Titulo = textBox1.Text;
            not.Descricao = textBox2.Text;
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem != "Nenhum")
                not.SelecaoId = ctx.Selecoes.First(x => x.Nome == comboBox1.SelectedItem.ToString()).Id;
            not.Importancia = comboBox2.SelectedItem.ToString();
            not.DataHoraCadastro = DateTime.Now;
            not.DataHoraEnvio = dateTimePicker3.Value.Date +  dateTimePicker2.Value.TimeOfDay;
            ctx.Notificacoes.Add(not);
            ctx.SaveChanges();
            "Cadastrado com sucesso".Information();
            this.Close();
        }

        private void InsertNotificationForm_Load(object sender, EventArgs e)
        {
            LoadCombo();
            dateTimePicker3.MinDate = DateTime.Now;
            dateTimePicker3.MaxDate = DateTime.Now.AddDays(30);
        }

   
        private void LoadCombo()
        {
            comboBox1.Items.Add("Nenhum");
            comboBox1.Items.AddRange(ctx.Selecoes.Select(x => x.Nome).ToArray());

            comboBox2.Items.Add("Padrão");
            comboBox2.Items.Add("Urgente");


            if (Item == null) return;
            comboBox2.SelectedItem = Item.Importancia;
            comboBox1.SelectedItem = Item.Selecoes.Nome;
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            button1.Enabled = IsFilled();
        }
        private bool IsFilled()
        {
            return !(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || comboBox2.SelectedItem == null || dateTimePicker2.Value == null || dateTimePicker2.Value.Hour == 0);
        }

    }
}
