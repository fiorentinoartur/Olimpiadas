using FiorentionoDesktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentionoDesktop
{
    public partial class parent : Form
    {

        public static Usuarios logado = new Usuarios();
        public ModuloDesktopEntities ctx = new ModuloDesktopEntities(); 
        public parent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void parent_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            PutStyle(panel1);
        }

        private void PutStyle(Control panel1)
        {
            foreach (Control c in panel1.Controls)
            {
               if(c is DataGridView dgv)
                {
                    dgv.AllowUserToAddRows = false;
                    dgv.ReadOnly = true;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgv.ColumnHeadersVisible = false;
                }
            }
        }
    }
}
