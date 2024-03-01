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
    public partial class CadastroFunc : FiorentinoForm.parent
    {
        public CadastroFunc()
        {
            InitializeComponent();
        }

        private void CadastroFunc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctx.People.ToList().Select(x => new
            {
                ID = x.ID,
                Nome = x.Name,
                Nascimento = x.BirthDay,
                TipoDoc = x.Documents.FirstOrDefault().DocTypeID,
                NumeroDoc = x.Name,
                Remover = "excluir"
            }).ToList();



            dataGridView1.Columns[0].Visible = false;
        }
    }
}
