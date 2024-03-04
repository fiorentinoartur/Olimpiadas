using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class CadastroFunc : FiorentinoForm.parent
    {
        public CadastroFunc()
        {
            InitializeComponent();
        }
        public People Usuario { get; }

        public CadastroFunc(People usuario)
        {
            Usuario = usuario;
        }


        private void CadastroFunc_Load(object sender, EventArgs e)
        {
           
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
