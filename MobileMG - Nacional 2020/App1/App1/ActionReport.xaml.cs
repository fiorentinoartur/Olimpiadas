using App1.Models;
using App1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionReport : ContentPage
    {
        private Relatos relato;
        protected String PhotoPath { get; set; }
        public bool isVisible { get; set; }
        public ActionReport()
        {
            InitializeComponent();
        }
        public ActionReport(Relatos relato)
        {
            InitializeComponent();
            this.relato = relato;
            editor.Text = relato.relato;
            longitude.Text = relato.longitude.ToString();
            latitude.Text = relato.latitude.ToString();
            imgFoto.Source = ImageSource.FromResource($"{relato.imagem.Split('.')[0]}.jpg");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            email.Text = UserDados.Usuario.email;
            id.Text = UserDados.Usuario.id.ToString();
            nome.Text = UserDados.Usuario.nome.ToString();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                container1.Orientation = StackOrientation.Horizontal;
                container2.Orientation = StackOrientation.Horizontal;
                save.WidthRequest = 250;
                cancelar.WidthRequest = 250;
                end.Margin = new Thickness(200, 0, 0, 0);

            }
            else
            {
                container1.Orientation = StackOrientation.Vertical;
                container2.Orientation = StackOrientation.Vertical;
                save.WidthRequest = 150;
                cancelar.WidthRequest = 150;
                end.Margin = new Thickness(0, 0, 0, 0);
            }


        }

        private async void foto_Clicked(object sender, EventArgs e)
        {
            var file = await MediaPicker.CapturePhotoAsync();
            imgFoto.Source = ImageSource.FromFile(file.FullPath);
        }

        private async void localizar_Clicked(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLocationAsync();
            latitude.Text = location.Latitude.ToString();
            longitude.Text = location.Longitude.ToString();

        }

        private async void save_Clicked(object sender, EventArgs e)
        {
            try
            {
                string relato = editor.Text;
                string img = "default.png";
                decimal latitudeD = Convert.ToDecimal(latitude.Text);
                decimal longitudeD = Convert.ToDecimal(longitude.Text);
                int idUser = UserDados.Usuario.id;
                if (switch1.IsToggled)
                    idUser = 0;
                var response = await ApiService<Relatos>.Get($"relatos/salvar?relato={relato}&imagem={img}&latitude={latitudeD}&longitude={longitudeD}&id={idUser}");
                if (response != null)
                {
                    await DisplayAlert("Informação", "Relato Salvo com sucesso!", "OK");
                    await Navigation.PopToRootAsync();
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "É preciso informar a localização e o relato", "OK");
                return;
                throw;
            }
        }

        private async void cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}