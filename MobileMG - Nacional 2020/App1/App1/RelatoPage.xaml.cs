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
	public partial class RelatoPage : ContentPage
	{
        private Relatos relato;

        public RelatoPage()
        {
            InitializeComponent();
        }

        public RelatoPage(Relatos relato)
        {
            InitializeComponent();
            this.relato = relato;
            BindingContext = relato;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                container.Orientation = StackOrientation.Horizontal;
                container2.Orientation = StackOrientation.Horizontal;
                image.WidthRequest = 150;
            }
            else
            {
                container.Orientation = StackOrientation.Vertical;
                container2.Orientation = StackOrientation.Vertical;
            }
        }

        private async void excluir_Clicked(object sender, EventArgs e)
        {
            await ApiService<Relatos>.GetList($"relatos/excluir?id={relato.id}");
            await DisplayAlert("Informação", "Relato excluido com sucesso!", "OK");
            await Navigation.PopAsync();
        }

        private void close_Clicked(object sender, EventArgs e)
        {
            modal.IsVisible = false;
        }

        private void showModal_Clicked(object sender, EventArgs e)
        {
            modal.IsVisible = true;
        }

        private async void edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionReport(relato));
        }
    }
}