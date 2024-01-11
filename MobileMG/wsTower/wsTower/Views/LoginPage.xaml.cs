using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wsTower.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}