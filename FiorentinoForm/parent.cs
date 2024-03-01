using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class parent : Form
    {
   public        LogisticsBDEntities ctx = new LogisticsBDEntities();
        public parent()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void parent_Load(object sender, EventArgs e)
        {
            GraphicsPath ellipse = new GraphicsPath();
            ellipse.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);

            pictureBox1.Region = new Region(ellipse);
            PutStyle(panel1);
        }

        private void PutStyle(Control panel)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is Panel)
                {
                    PutStyle(c);
                }


                if (c is DataGridView dgv)
                {
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgv.RowHeadersVisible = false;
                    dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hide();
            new FrequenciaFunc().ShowDialog();
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hide();
            new CadastroFunc().ShowDialog();
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Hide();
            new LancamentoVale().ShowDialog();
            Close();
        }
    }
}
