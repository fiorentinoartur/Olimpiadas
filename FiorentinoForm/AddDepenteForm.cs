using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class AddDepenteForm : FiorentinoForm.parent
    {
        public AddDepenteForm()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
        }

        private void AddDepenteForm_Load(object sender, EventArgs e)
        {



            LoadData();
        }

        private void LoadData()
        {
            flowLayoutPanel1.Controls.Clear();
            var listaDependentes = ctx.People.Where(x => x.ResponsibleID == PeopleCadastro.usuario.ID).ToList();

            foreach (var item in listaDependentes)
            {
                var card = new DependentesControl(item);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new CadastroFunc().Show();
            Close();

        }
    }
}
