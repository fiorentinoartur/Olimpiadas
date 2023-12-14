using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telas.Models;
using Telas.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RankingPage : ContentPage
    {
     public   ObservableCollection<PersonModel> ListaRanking { get; set; } = new ObservableCollection<PersonModel>();
        

        public RankingPage()
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
            foreach (var item in listaRanking)
            {
                ListaRanking.Add(item);
            }
        }
    }
}