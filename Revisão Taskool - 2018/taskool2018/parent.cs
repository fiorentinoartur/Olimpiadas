using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using taskool2018.Modal;

namespace taskool2018
{
    public partial class parent : Form
    {
       public dbTarefasEntities ctx = new dbTarefasEntities();
        public string mensagens = AppDomain.CurrentDomain.BaseDirectory + "mensagens";
        public string musicas = AppDomain.CurrentDomain.BaseDirectory + "musicas-teste";
        public string semFoto = AppDomain.CurrentDomain.BaseDirectory + "user";
        public parent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void parent_Load(object sender, EventArgs e)
        {
            PutStyle(panel1);
        }

        private void PutStyle(Control panel)
        {
            foreach (Control c in panel.Controls)
            {
                if(c is Panel || c is FlowLayoutPanel || c is GroupBox || c is UserControl || c is TabControl  || c is TabPage )
                {
                    PutStyle(c);
                }

                if(c is ComboBox combo)
                {
                    combo.DropDownStyle = ComboBoxStyle.DropDownList;
                }

                if(c is DataGridView dgv)
                {
                    dgv.AllowUserToAddRows = false;
                    dgv.ReadOnly = true;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgv.RowHeadersVisible = false;
                }
            }
        }


    }
    public static class ME
    {
        public static DialogResult Alert(this string text)
        {
            return MessageBox.Show(text, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Information(this string text)
        {
            return MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
