using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if (usuarioInput.Text == "artur" && senhaInput.Text == "123")
            {
                //Redirecionar par outra tela
                App.Current.MainPage = new TelaLogado();
            }
            else
            {
                await DisplayAlert("Alerta", "Usuário ou senha inválidos", "Ok");
            }
        }
    }
}