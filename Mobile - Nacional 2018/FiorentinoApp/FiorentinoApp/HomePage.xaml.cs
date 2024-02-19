using FiorentinoApp.Models;
using FiorentinoApp.Service;
using FiorentinoApp.ViewModels;
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
    public partial class HomePage : ContentPage
    {
        BaseVM vm = new BaseVM();
        public HomePage()
        {
            InitializeComponent();
            BindingContext = vm;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var response = await ApiService<Usuario>.GetList("Usuario/Get");

            vm.Usuarios.Clear();
            foreach (var item in response)
            {
                vm.Usuarios.Add(item);
            }
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var usuario = e.CurrentSelection.FirstOrDefault() as Usuario;
            UserDados.usuario = usuario;
            App.Current.MainPage = new NavigationPage(new MobileFlyout());
        }
    }
}