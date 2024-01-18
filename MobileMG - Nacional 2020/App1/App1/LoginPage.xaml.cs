using App1.Models;
using App1.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            labelInvalido.IsVisible = false;
            entry_senha.IsPassword = true;

            entry_user.Text = "juliane2009@gmail.com";
            entry_senha.Text = "6654";
            //entry_senha.TextChanged += EntrySenha_TextChanged;

        }
        //private void EntrySenha_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    senhaAtual = e.NewTextValue;
        //    entry_senha.Text = new string('*', e.NewTextValue.Length);
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

        private async void LoadData()
        {
            var listaUsuario = await ApiService<UsuarioViewModel>.GetList("usuarios");
            foreach (var item in listaUsuario)
            {
                ListaUsuarios.Add(item);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            var loginModel = new LoginUser
            {
                email = entry_user.Text,
                senha = entry_senha.Text
            };
            var isAuthenticated = await ApiService<LoginUser>.Login(loginModel);
            if (isAuthenticated == null)
            {

                labelInvalido.Text = "Usuário/Senha Inválidos";
                labelInvalido.IsVisible = true;
                contador++;

                if (contador >= 3)
                {
                    entry_senha.IsEnabled = false;
                    entry_user.IsEnabled = false;
                    btn_Login.IsEnabled = false;
                    labelInvalido.Text = "Login Bloqueado aguarde 30s";
                    await Task.Delay(5000);

                    contador = 0;
                    labelInvalido.IsVisible = false;
                    entry_senha.IsEnabled = true;
                    entry_user.IsEnabled = true;
                    btn_Login.IsEnabled = true;

                }
                return;

            }
           
                App.Current.MainPage = new WsTowerFlyout();

            
           
            
            

        }
    }
}
