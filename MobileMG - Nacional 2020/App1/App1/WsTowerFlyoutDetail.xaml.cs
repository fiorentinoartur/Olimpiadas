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

        private void AbrirModal(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ModalInformation());
        }
    }
}