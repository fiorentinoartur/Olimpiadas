using FiorentinoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiorentinoForm
{
    public partial class DependentesControl : UserControl
    {
        public DependentesControl()
        {
            InitializeComponent();
        }

        public DependentesControl(People item)
        {
            InitializeComponent();
            Item = item;
            checkBox1.Text = item.Name;
        }

        public People Item { get; }

        private void DependentesControl_Load(object sender, EventArgs e)
        {
         
        }
    }
}
