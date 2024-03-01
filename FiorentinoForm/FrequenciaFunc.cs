using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class FrequenciaFunc : FiorentinoForm.parent
    {
        public FrequenciaFunc()
        {
            InitializeComponent();
        }

        private void FrequenciaFunc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctx.Frequencies.ToList().Select(x => new
            {
                Id = x.ID,
                Funcionario = x.Employees.People.Name,
                Data= x.Date,
                Entrada = x.Checkin,
                Saida = x.Checkout,
                Faltas = x.Attachment,
                Atestado = x.Checkin,
                Presencas = x.Date,
            }).ToList();


            dataGridView1.Columns[0].Visible = false;
      }
    }
}
