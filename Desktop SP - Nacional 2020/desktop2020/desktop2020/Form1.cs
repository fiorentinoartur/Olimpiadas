using desktop2020.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using System.Runtime.InteropServices.ComTypes;

namespace desktop2020
{
    public partial class Form1 : parent
    {
        Settings settings = Settings.Default;
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var videos = Directory.GetFiles(videosFolder).ToList();

            var video = videos[settings.video];
            if(video == null)
            {
                "No videos were found".Alert();
                return;
            }
            settings.video++;
            if (settings.video == videos.Count)
                settings.video = 0;

            settings.Save();
            axWindowsMediaPlayer1.URL = video;
            axWindowsMediaPlayer1.PlayStateChange += MidiaPlayer_PlayStateChange;
           
            
        }
        private void MidiaPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 8)
            {
                this.Hide();

                if(settings.keep)
                {
                    Dados.Logged = ctx.Usuarios.Find(settings.idUser);
                    new UserForm().Show();
                }
                else
                {
                    new LoginForm().Show();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
