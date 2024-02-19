using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FiorentinoApp
{
    public partial class MainPage : ContentPage
    {
      public  Brush colorWhite = Brush.White;
        public Brush colorRed = Brush.Red;
        public Brush colorBlue = Brush.Blue;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadColors();
        }

        private async void LoadColors()
        {
            for (int i = 0; i < 6; i++)
            {
                var colorIntermediaria = colorWhite;
                colorWhite = colorRed;
                colorRed = colorBlue;
                colorBlue = colorIntermediaria;

                circle1.Fill = colorWhite;
                circle2.Fill = colorRed;
                circle3.Fill = colorBlue;
                await Task.Delay(500);

            }
           App.Current.MainPage = new HomePage();
        }
    }
}
