using App1.Models;
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
    public partial class WsTowerFlyout : FlyoutPage
    {
        public UsuarioViewModel usuario { get; set; }
        public WsTowerFlyout()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;


            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as WsTowerFlyoutFlyoutMenuItem;
            if (item == null)
                return;

            if(item.Id == 3)
            {
                App.Current.MainPage = new LoginPage();
            }
            if (item == null || !item.isEnable)
            {
                DisplayAlert("Alerta", "Acesso apenas para administradores!", "OK");
                return;

            }
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}