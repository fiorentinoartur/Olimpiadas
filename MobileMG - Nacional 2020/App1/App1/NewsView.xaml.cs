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
    public partial class NewsView : ContentPage
    {
        public ObservableCollection<Relatos> ListaRelatos { get; set; } = new ObservableCollection<Relatos>();

        public NewsView()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
          
        }

    
        private void AbrirRelato(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            if (button.CommandParameter is int  relatoId)
            {
                Navigation.PushAsync(new RelatoPage(relatoId));

            }
        }
    }
}
