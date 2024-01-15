using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace taskool2018
{
    public partial class PrincipalPageForm : taskool2018.parent
    {
        private int idUsuario;
       
        public PrincipalPageForm(int Codigo1)
        {
            InitializeComponent();
            idUsuario = Codigo1;
        }

        private void PrincipalPageForm_Load(object sender, EventArgs e)
        {
            var text = Encoding.UTF8.GetString(Properties.Resources.m);
 
        }

        public void AtualizarDados()
        {
            DateTime dateTime = DateTime.Now;
            int Hour = dateTime.Hour;

            var user = ctx.Usuario.FirstOrDefault(x => x.Codigo == idUsuario);

            string nome = user.Nome;
            string[] partName = nome.Split(' ');
            string firstName = partName[0];

            string saudacao = "";
            if (Hour > 12 && Hour < 18)
            {
                saudacao = $"Boa Tarde, {firstName}";
            }
            else if(Hour > 18 && Hour < 24)
            {
                saudacao = $"Boa Noite, {firstName}";
            }
            else if(Hour > 0 && Hour < 4)
            {
                saudacao = $"Boa Madrugada, {firstName}";
            }
            else if(Hour > 4 && Hour < 12)
            {
                saudacao = $"Bom dia, {firstName}";
            }
            labelSaudacao.Text = saudacao;
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            horario.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}
