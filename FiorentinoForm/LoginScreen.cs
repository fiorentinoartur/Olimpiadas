using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class LoginScreen : Form
    {
        public LogisticsBDEntities2 ctx =  new LogisticsBDEntities2();
        int tries = 3;
        int ms = 1000;
        public LoginScreen()
        {
            InitializeComponent();
            textBox1.Text = "Aline.Moraes@live.com";
            textBox2.Text = "w4OLymDSyE";


        }


        private void button1_Click(object sender, EventArgs e)
        {

            SHA256 sha = SHA256.Create();
            var result = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(textBox2.Text))).Replace("-", "").ToLower();


            var user = ctx.People.FirstOrDefault(x => x.Email == textBox1.Text);

            if (user != null)
            {
                if (user.Password == textBox2.Text)
                {
                    UserDados.usuario = user;
                    new Form1().Show();
                    this.Hide();
                    return;
                }



                if (tries >= 0)
                {

                    tries--;
                    MessageBox.Show($@"The user email or password was incorrect.
{tries}  tries remaining", "Logistic system - Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                if (tries == 0)
                {
                    BlockLogin();
                }


            }





        }

        private void BlockLogin()
        {
            ms *= 2;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

   
    }
}
