using System;
using System.ComponentModel;
using wsTower.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wsTower.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {

            this.BindingContext = new AboutViewModel();
        }


    }
}