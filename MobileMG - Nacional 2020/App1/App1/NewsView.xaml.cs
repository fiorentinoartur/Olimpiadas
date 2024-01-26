using App1.Models;
using App1.Service;
using App1.ViewModels;
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
    public partial class NewsView : ContentPage
    {
        BaseVM vm = new BaseVM();
        public ObservableCollection<Relatos> ListaRelatos { get; set; } = new ObservableCollection<Relatos>();

        public NewsView()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadData();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if(width > height)
            {
                Collection.IsVisible = true;
                listView.IsVisible = false;
            }
            else
            {
                Collection.IsVisible=false;
                listView.IsVisible=true;
            }
        }
        private async Task LoadData()
        {
            var lista = await ApiService<Relatos>.GetList("relatos");
            vm.Relatos.Clear();
            foreach (var item in lista)
            {
                vm.Relatos.Add(item);
            }
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var relato = e.SelectedItem as Relatos;
            Navigation.PushAsync(new RelatoPage(relato));
        }

        private void Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var relato = e.CurrentSelection.FirstOrDefault() as Relatos;
            Navigation.PushAsync(new RelatoPage(relato));
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var id = Convert.ToInt32((sender as MenuItem).BindingContext);
            await ApiService<Relatos>.GetList($"relatos/excluir?id={id}");
            await DisplayAlert("Informação", "Relato excluído com sucesso", "Ok");
            await LoadData();
        }
    }
}
