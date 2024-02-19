using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class NewPassForm : FiorentionoDesktop.parent
    {
        public NewPassForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = ctx.Usuarios.Find(logado.IdUsuario);

            user.Senha = textBox1.Text;

            ctx.Entry(user).CurrentValues.SetValues(user);

            ctx.SaveChanges();
       
            new LoginForm().Show();
            this.Close();
        }
    }
}
