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
    public partial class ForgotPass : FiorentionoDesktop.parent
    {
       string senhaAleatoria;
       
        public ForgotPass()
        {
            InitializeComponent();
            dateTimePicker1.Visible = false;
            textBox1.Visible = false;
            button2.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {
            
            label1.Text = "Qual a sua data de Nascimento?";
            dateTimePicker1.Visible = true;

        }

        private void ValidarUser(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date == logado.nascimento)
            {
              
                dateTimePicker1.Visible = false;
                textBox1.Visible = true;
                label1.Text = "Qual seu time favorito?";  
                
            }
           if (textBox1.Text.ToLower().Trim() == logado.timeFavorito.ToLower().Trim())
            {
                textBox1.Text = "";
                label1.Text = "Qual sua cor favorita?";

            }
             if (textBox1.Text.Trim().ToLower() == logado.corFavorita.Trim().ToLower())
            {
                textBox1.Text = "";
                label1.Text = "Qual o seu apelido?";

            }
            if (textBox1.Text.Trim().ToLower() == logado.apelido.Trim().ToLower())
            {
                textBox1.Text = "";
          
                string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
                string letrasMaiusculas = "abcdefghijklmnopqrstuvwxyz".ToUpper(); 
                Random random = new Random();
                senhaAleatoria = new string(Enumerable.Range(0, 6)
                    .Select(_ => $"{letrasMinusculas}{letrasMaiusculas}0123456789"[random.Next($"{letrasMinusculas}{letrasMaiusculas}0123456789".Length)])
                    .ToArray());

                var user = ctx.Usuarios.Find(logado.IdUsuario);

                user.Senha = senhaAleatoria;
               

                ctx.Entry(user).CurrentValues.SetValues(user);
                ctx.SaveChanges();
                $"Senha alterada com sucesso!".Information();
                button2.Visible = true;
        
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(senhaAleatoria);
            new LoginForm().Show();
            this.Close();
        }
    }
}
