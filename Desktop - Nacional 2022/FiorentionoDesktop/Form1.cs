using FiorentionoDesktop.Model;
using FiorentionoDesktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class Form1 : parent
    {
        Settings settings  = Settings.Default;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "teste@email.com";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var user = ctx.Usuarios.Where(x => x.Email == textBox1.Text).FirstOrDefault();
            if (user == null)
            {
                "Email não Cadastrado".Alert();
                return;
            }
            logado = user;
            if (user.DataCadastro == null)
            {
                if (user.DataConvite.AddDays(30) < DateTime.Now)
                {
                    "Data de convite expirada".Information();
                    Notificacao not = new Notificacao();
                    not.dataHora = DateTime.Now;
                    not.notificacao1 = $"Usuário {user.Email} está com a data expirada";
                    not.status = "p";
                    not.idusuario = user.idIndicado ?? 1;
                    ctx.Notificacao.Add(not);
                    ctx.SaveChanges();
                    return;
                }
                new SingUpForm().Show();
            }
            else
            {
                new LoginForm().Show();
            }
            this.Hide();

        }
    }
}
