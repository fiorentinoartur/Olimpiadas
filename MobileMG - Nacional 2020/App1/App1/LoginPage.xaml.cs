using App1.Models;
using App1.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public ObservableCollection<UsuarioViewModel> ListaUsuarios { get; set; } = new ObservableCollection<UsuarioViewModel>();
        int contador = 0;

        public LoginPage()
        {
            InitializeComponent();

            email.Text = "Jota.rc1@hotmail.com";
            senha.Text = "65885";


        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "ForcePortrait");
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if(email.Text == null || senha.Text == null) 
            {
                DependencyService.Get<IToast>().Show("Usuário/Senha inválidos");
                contador++;
                await BlockLogin();
                return;
            }
         
            string emailString = email.Text;
            string senhaString = senha.Text;

            var response = await ApiService<UsuarioViewModel>.Get($"login?email={emailString}&senha={senhaString}");

            if(response == null) 
            {
                DependencyService.Get<IToast>().Show("Usuário/Senha inválidos");
                contador++;
                await BlockLogin();
                return;
            }
            UserDados.Usuario = response;
            await DisplayAlert("Informação", $"Bem-vindo {response.nome}!", "Ok");
         
            var wsTowerFlyoutPage = new WsTowerFlyout();

            // Configuração para ocultar a barra de navegação na página WsTowerFlyout
            NavigationPage.SetHasNavigationBar(wsTowerFlyoutPage, false);

            // Defina a nova MainPage como uma NavigationPage
            App.Current.MainPage = new NavigationPage(wsTowerFlyoutPage);

        }

        private async Task BlockLogin()
        {
            if (contador == 3)
            {
                DependencyService.Get<IToast>().Show("Login bloqueado: aguardar 30s!");
                email.IsEnabled = false;
                senha.IsEnabled = false;
                btnLogin.IsEnabled = false;
                await Task.Delay(30000);
                contador = 0;
                email.IsEnabled = true;
                senha.IsEnabled = true;
                btnLogin.IsEnabled = true;
            }
        }
    }
    }

