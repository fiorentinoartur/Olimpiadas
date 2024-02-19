using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FiorentinoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public Brush Color1 { get; set; } = Brush.White;
        public Brush Color2 { get; set; } = Brush.Red;
        public Brush Color3 { get; set; } = Brush.Blue;
        public SplashScreen()
        {
            InitializeComponent();
        
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ChangeColor();  

        }


        private async void ChangeColor()
        {
            for (int i = 0; i < 6; i++)
            {
                var colorIntermetiate = Color1;
                Color1 = Color2;
                Color2 = Color3;
                Color3 = colorIntermetiate;


                circle1.Fill = Color1;
                circle2.Fill = Color2;
                circle3.Fill = Color3;
                await Task.Delay(500);
            }
            App.Current.MainPage = new NavigationPage(new HomePage());
        }

     
    }
}