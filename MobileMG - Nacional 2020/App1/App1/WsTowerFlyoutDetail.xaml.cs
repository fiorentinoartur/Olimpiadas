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
            var modal = new ModalInformation();

          
            var absoluteLayout = new AbsoluteLayout();

            
            AbsoluteLayout.SetLayoutFlags(modal, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(modal, new Rectangle(0.5, 0.5, 0.8, 0.8));

           

   
            modal.Content = absoluteLayout;

            Navigation.PushModalAsync(modal);
        }

    }
}