using System;
using wsTower.Services;
using wsTower.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wsTower
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
