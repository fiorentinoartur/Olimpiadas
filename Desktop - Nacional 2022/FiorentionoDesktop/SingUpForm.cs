using FiorentionoDesktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class SingUpForm : FiorentionoDesktop.parent
    {
        public SingUpForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void SingUpForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = logado.Email;
            textBox1.Enabled = false;

            textBox2.Text = logado.Senha;
            textBox3.Text = logado.apelido;
            textBox4.Text = logado.corFavorita;
            textBox5.Text = logado.timeFavorito;
            dateTimePicker1.Value = logado.nascimento ?? DateTime.Now;

            if (logado.Foto != null)
            {
                MemoryStream ms = new MemoryStream(logado.Foto);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                "Todos os campos são obrigatórios exceto a foto".Alert();
                return;
            }
            var apelido = ctx.Usuarios.Where(x => x.apelido == textBox3.Text).FirstOrDefault();
            var email = ctx.Usuarios.Where(x => x.Email == textBox1.Text).FirstOrDefault();
            var datacadastro = email.DataCadastro;
            if (logado.DataCadastro == null)
            {
                if (apelido != null)
                {
                    "Apelido já cadastrado".Alert();
                    return;
                }
                email.DataCadastro = DateTime.Now;
                Notificacao not = new Notificacao();
                not.dataHora = DateTime.Now;
                not.notificacao1 = $"Convidado {logado.Email} realizou o cadastro em {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";
                not.idusuario = logado.idIndicado ?? 1;
                not.status = "p";
                ctx.Notificacao.Add(not);
            }
            else
            {

                if (apelido.IdUsuario != email.IdUsuario)
                {
                    "Apelido já cadastrado".Alert();
                    return;
                }
            }


            email.Senha = textBox2.Text;
            email.apelido = textBox3.Text;
            email.corFavorita = textBox4.Text;
            email.timeFavorito = textBox5.Text;
            email.nascimento = dateTimePicker1.Value;
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            email.Foto = ms.ToArray();

            ctx.Entry(email).CurrentValues.SetValues(email);
            ctx.SaveChanges();

            "Dados salvos com sucesso!".Information();
            this.Close();
            if (datacadastro == null)
            {
                new PrincipalForm().Show();

            }

        }
    }
}
