using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop2020
{
    public partial class ForgotPassForm : parent
    {
        private bool passValid;
        public ForgotPassForm()
        {
            InitializeComponent();
            Txt_Senha.TextChanged += TxtChanged2;
            Txt_ConfirmSenha.TextChanged += TxtChanged2;

            Txt_Senha.TextChanged += TxtChanged1;
            passValid = button1.Enabled = Txt_Senha.Enabled = Txt_ConfirmSenha.Enabled = false;
        }

        private bool validarSenha(string senha)
        {
            string pattern = @"^(?=.*\d)[a-z0-9]{8,15}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(senha);    
        }
        private void TxtChanged1(object sender, EventArgs e)
        {
            if (!validarSenha(Txt_Senha.Text))
            {
                passValid = button1.Enabled = false;
            }
            else
            {
                passValid = button1.Enabled = true;
            }
                Txt_Security.BackColor = Color.Green;
                Txt_Security.Text = "Forte";

                var repetition1 = Txt_Senha.Text.GroupBy(x => x).Any(g => g.Count() == 2);
                var repetition2 = Txt_Senha.Text.GroupBy(x => x).Any(g => g.Count() > 2);

                if (repetition1)
                {
                    Txt_Security.BackColor = Color.Yellow;
                    Txt_Security.Text = "Médio";
                }

                if (repetition2)
                {
                    Txt_Security.BackColor = Color.Red;
                    Txt_Security.Text = "Fraca";
                }
        }

        private void TxtChanged2(object sender, EventArgs e)
        {
            if (Txt_Senha.Text == Txt_ConfirmSenha.Text)
            {
                Txt_SenhaIgual.BackColor = Color.Green;
                Txt_SenhaIgual.Text = "Senhas identicas";
                passValid = true;
            }
            else
            {
                Txt_SenhaIgual.BackColor = Color.Red;
                Txt_SenhaIgual.Text = "Senhas não correspondem";
                passValid = false;
            }
        }
        private void ForgotPassForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(ctx.Selecoes.Select(x => x.Nome).ToArray());
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() != Dados.Logged.Selecoes.Nome || dateTimePicker1.Value.Date != Dados.Logged.Nascimento.Date)
            {
                Txt_Senha.Enabled = Txt_ConfirmSenha.Enabled = false;
            }
            else
            {
                Txt_Senha.Enabled = Txt_ConfirmSenha.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!passValid) return;

            var user = ctx.Usuarios.Find(Dados.Logged.Id);

            user.Senha = Txt_Senha.Text;
            ctx.Entry(user).CurrentValues.SetValues(user);
            ctx.SaveChanges();

            "Succes!".Information();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
