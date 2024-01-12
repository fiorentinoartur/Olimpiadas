using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using webDesktop2020.Modal;

namespace webDesktop2020
{
    public partial class parent : Form
    {
        public Sessao5Entities2 ctx = new Sessao5Entities2();
        public string videosFolder = AppDomain.CurrentDomain.BaseDirectory + "Videos";
        public string ADM = "0";
        public string USER = "1";
        public parent()
        {
            InitializeComponent();
        }
    }
}
