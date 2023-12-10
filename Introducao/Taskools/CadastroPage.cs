using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taskool
{
    public partial class CadastroPage : Form
    {
        public CadastroPage()
        {
            InitializeComponent();
        }
        DesktopPREntities ctx = new DesktopPREntities();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            var validarEmail = ctx.Pessoa.FirstOrDefault(x => x.Email == Txt_Email.Text);
            Usuarios user = new Usuarios(); 
            if( validarEmail != null)
            {
                MessageBox.Show("Email já cadastrado");
                return;
            }
            if (Txt_Email.Text == "" || Txt_Usuario.Text == "" || Txt_Nome.Text == "" || Txt_Telefone.Text == "" )
            {
                MessageBox.Show("Preencha os campos corretamente");
                return;
            }
            user.


        }
    }
}
