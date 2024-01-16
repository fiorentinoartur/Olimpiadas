using App1.Models;
using App1.Services;
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
      public  ObservableCollection<PersonModel> ListaRanking { get; set; } = new ObservableCollection<PersonModel>();
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

        private async void LoadData()
        {
            var listaRanking = await ApiService<PersonModel>.GetList("Ranking");

            foreach (var item in listaRanking.OrderByDescending(x => x.pontos)
            {
                ListaRanking.Add(item);
            }

        }
    }
}