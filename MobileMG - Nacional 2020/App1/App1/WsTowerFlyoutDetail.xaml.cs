using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WsTowerFlyoutDetail : ContentPage
    {
        public WsTowerFlyoutDetail()
        {
            InitializeComponent();
        }

        private async void AbrirModal(object sender, EventArgs e)
        {
            await DisplayAlert("Informação", "V1.0.0 Desenvolvido por <Artur Fiorentino> <DR> durante a seletiva escolar de 2024.", "OK");
        }

    }
}