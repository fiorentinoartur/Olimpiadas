using App1.Models;
using App1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionReport : ContentPage
    {
        protected String PhotoPath { get; set; }
        public bool isVisible { get; set; }
        public ActionReport()
        {
            InitializeComponent();
        }

        async Task TakePhotoAsync()
        {

            var photo = await MediaPicker.CapturePhotoAsync();
            await LoadPhotoAsync(photo);

        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;

        }

        private async void Selecionar_Imagem(object sender, EventArgs e)
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                await TakePhotoAsync();

                imgFoto.Source = ImageSource.FromFile(PhotoPath);
            });


        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
           isVisible = e.Value;
        }




        private async void Cadastrar_Relato(object sender, EventArgs e)
        {

     
            if (!isVisible)
            {
                var cadastrarRelato = new CadastrarRelato
                {
                    usuarioId = UserDados.Usuario.id,
                    Longitude = decimal.Parse(LabelLongitude.Text),
                    Latitude = decimal.Parse(LabelLatitute.Text),
                    Imagem = PhotoPath,
                    Relato = relatoTexto.Text,

                };
                

            }
            else
            {
                var cadastrarRelatoo = new CadastrarRelato
                {
       
                    Longitude = decimal.Parse(LabelLongitude.Text),
                    Latitude = decimal.Parse(LabelLatitute.Text),

                    Relato = relatoTexto.Text,

                };
              
            }
                

           
            //else
            //{
            //    relato.Longitude = decimal.Parse(LabelLongitude.Text);
            //    relato.Latitude = decimal.Parse(LabelLongitude.Text);
            //    relato.Imagem = PhotoPath;
            //    relato.Relato = relatoTexto.Text;
            //}
  

        }

        private async void GerarLocalizacao(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    double latitude = location.Latitude;
                    double longitude = location.Longitude;

                    LabelLatitute.Text = $"{latitude}";
                    LabelLongitude.Text = $"{longitude}";


                }
                else
                {
                    LabelLatitute.Text = $"Indisponivel";
                    LabelLongitude.Text = $"Indisponivel";
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Feature not supported: {ex.Message}");
            }
 
        }
    }
}