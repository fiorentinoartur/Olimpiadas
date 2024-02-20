using FiorentionoDesktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class SettingsForm : FiorentionoDesktop.parent
    {
        Settings settings = new Settings();
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = ctx.Usuarios.Find(logado.IdUsuario).RecebeNotificacao.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var user = ctx.Usuarios.Find(logado.IdUsuario);
            user.RecebeNotificacao = checkBox1.Checked;
            ctx.Entry(user).CurrentValues.SetValues(user);
            ctx.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.keep = false;
            settings.idUser = 0;
            settings.Save();

            "A senha foi limpa com sucesso!".Information();
            this.Close();
        }
    }
}    
