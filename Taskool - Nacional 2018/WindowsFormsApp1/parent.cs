using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class parent : Form
    {
       public dbTarefasEntities2 ctx = new dbTarefasEntities2();
        public static Usuario logado = new Usuario();
        public static Color hex = Color.White;
        public parent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
           
        }

        private void parent_Load(object sender, EventArgs e)
        {
            PutStyle(panel1);
        }

       private void PutStyle(Control panel)
        {
            panel.BackColor = hex;

        }
    }
}
