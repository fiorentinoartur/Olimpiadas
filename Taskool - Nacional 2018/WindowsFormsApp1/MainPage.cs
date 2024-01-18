﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsApp1
{
    public partial class MainPage : parent
    {
        string lang = "pt";
       WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        public MainPage()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            pt.BackColor = Color.Green;
            en.BackColor = Color.Blue;
            timer1.Start();
            groupBox1.Visible = false;


            string path = "C:\\colors";
            string file = path + $"\\{logado.Codigo}.txt";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if(File.Exists(file)) 
            {
            string text = File.ReadAllText(file);
                hex = ColorTranslator.FromHtml(text);
            }

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            if(logado.Foto != null)
            {
                MemoryStream ms = new MemoryStream(logado.Foto);
                pictureBox1.Image = Image.FromStream(ms);
            }

           var text = Encoding.UTF8.GetString(Properties.Resources.mensagens);

            var lista = JsonConvert.DeserializeObject<JsonMessage[]>(text).ToList();
            Random random = new Random();
            int i = random.Next(lista.Count);
            var json = lista[i];
            label3.Text = json.Mensagem;
            label4.Text = json.Autor;
            SetSong();
        }

        private void SetSong()
        {
            Random rand = new Random();

            var playList = wmp.playlistCollection.newPlaylist("playList");
            //  var path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            var path = @"C:\Users\Artur Fiorentino\OneDrive\Área de Trabalho\Olimpiadas\Revisão Taskool - 2018\WindowsFormsApp1\bin\Debug\musicas-teste";


            int i = rand.Next(3);
            var files = Directory.GetFiles(path, "*.mp3").OrderBy(x => rand.Next());

            foreach(var item in files)
            {
                var media = wmp.newMedia(item);
                playList.appendItem(media);
            }
            wmp.currentPlaylist = playList;
            wmp.controls.stop();
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortTimeString();

            if (lang == "pt")
            {
                if (DateTime.Now.Hour < 4)
                {
                    label2.Text = $"Boa madrugada,{logado.Nome}!";
                }
                else if (DateTime.Now.Hour < 12)
                {
                    label2.Text = $"Bom dia,{logado.Nome}!";
                }
                else if (DateTime.Now.Hour < 18)
                {
                    label2.Text = $"Boa tarde,{logado.Nome}!";
                }
                else if (DateTime.Now.Hour < 24)
                {
                    label2.Text = $"Boa noite,{logado.Nome}!";
                }
            }
            else
            {
                if (DateTime.Now.Hour < 4)
                {
                    label2.Text = $"Good sun-up,{logado.Nome}!";
                }
                else if (DateTime.Now.Hour < 12)
                {
                    label2.Text = $"Good morning,{logado.Nome}!";
                }
                else if (DateTime.Now.Hour < 18)
                {
                    label2.Text = $"Good afternoon,{logado.Nome}!";
                }
                else if (DateTime.Now.Hour < 24)
                {
                    label2.Text = $"Good evening,{logado.Nome}!";
                }
            }

            if (wmp.currentMedia == null)
            {
                label5.Text = "Sem midia";
            }
            else
                label5.Text = wmp.currentMedia.name;


        }

        private void play_Click(object sender, EventArgs e)
        {
            if(play.Text == "Play")
            {
                wmp.controls.play();
                label5.Text = "Pause";
            }
            else
            {
                wmp.controls.stop();
                play.Text = "Play";
            }
        }

        private void pt_Click(object sender, EventArgs e)
        {
            lang = "pt";
            pt.BackColor = Color.Green;
            en.BackColor = Color.LightGreen;
        }

        private void en_Click(object sender, EventArgs e)
        {
            lang = "en";
            pt.BackColor = Color.LightGreen;
            en.BackColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            new SelectColor().Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }
    }
}