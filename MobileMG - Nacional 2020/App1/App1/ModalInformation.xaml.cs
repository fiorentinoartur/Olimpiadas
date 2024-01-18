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
    public partial class ModalInformation : ContentPage
    {
        public ModalInformation()
        {
            InitializeComponent();
        }

        private void FecharModal(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}