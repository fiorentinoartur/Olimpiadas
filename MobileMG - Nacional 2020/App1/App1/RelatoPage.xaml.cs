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
		public ObservableCollection<Relatos> RelatoX { get; set; } = new ObservableCollection<Relatos>();
        int IdFoto;
		public RelatoPage (int id)
		{
			InitializeComponent ();

			IdFoto = id;
		    BindingContext = this;

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
	
        }


        private void OnOptionsButtonClicked(object sender, EventArgs e)
        {

        }
    }
}