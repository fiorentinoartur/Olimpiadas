using FiorentionoDesktop;
using FiorentionoDesktop.Components;
using FiorentionoDesktop.Model;
using FiorentionoDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FiorentionoDesktop
{
    public partial class MeusConvidadosForm : FiorentionoDesktop.parent
    {
        DataTable dt = new DataTable(); 
        public MeusConvidadosForm()
        {
            InitializeComponent();
         //   dt.Columns.Add("Foto");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Status");
        
        }

        private void MeusConvidadosForm_Load(object sender, EventArgs e)
        {
      
        }


  

        private void button1_Click(object sender, EventArgs e)
        { 
            var users = ctx.Usuarios.Where(x => x.idIndicado == logado.IdUsuario).OrderBy(x => x.Email).ToList();

            foreach (var item in users)
            {
                if(item.DataConvite.Date.AddDays(30) < DateTime.Now)
                {
                    item.DataConvite = DateTime.Now;
                    ctx.Entry(item).CurrentValues.SetValues(item);
                }
            }
            "Convites revalidados!".Information();
            ctx.SaveChanges();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                LoadFlow();
                return;
            }
            var convidados = ctx.Usuarios.Where(x => x.idIndicado == logado.IdUsuario).OrderBy(x => x.Email).ToList();
            convidados = convidados.Where(x => x.apelido == null || x.apelido.ToLower().Contains(textBox1.Text.ToLower()) || x.Email.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            convidados = convidados.Where(x => x.apelido != null).ToList();
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in convidados)
            {
                var card = new ConvidadoControl(item);
                flowLayoutPanel1.Controls.Add(card);
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new ConvitePage().ShowDialog();
        }

        private void MeusConvidadosForm_Activated(object sender, EventArgs e)
        {
            LoadFlow();
        }

        private void LoadFlow()
        {
          flowLayoutPanel1.Controls.Clear();
            var convidados = ctx.Usuarios.Where(x => x.idIndicado == logado.IdUsuario).OrderBy(x => x.Email).ToList();
            foreach (var item in convidados)
            {
                var card = new ConvidadoControl(item);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}




