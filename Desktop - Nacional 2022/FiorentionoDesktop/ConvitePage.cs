using FiorentionoDesktop.Model;
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
    public partial class ConvitePage : FiorentionoDesktop.parent
    {
        public ConvitePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = ctx.Usuarios.Where(x => x.Email == textBox1.Text).FirstOrDefault();
            if (user != null)
            {
                "Email já cadastrado".Alert();
                return;
            }
            Usuarios usuario = new Usuarios();
            usuario.Email = textBox1.Text;
            usuario.idIndicado = logado.IdUsuario;
            usuario.DataConvite = DateTime.Now;
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
            "Usuário convidado com sucesso!".Information();
            this.Close();
        }
    }
}
