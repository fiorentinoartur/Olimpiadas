using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FiorentinoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MobileFlyout : FlyoutPage
    {
        public MobileFlyout()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MobileFlyoutFlyoutMenuItem;
            if (item == null)
                return;

            if(item.Id == 0)
            {
            PhoneDialer.Open("+738930000");
                LoadChange();
            }
            else if(item.Id == 1) 
            {
              await  Launcher.OpenAsync(new Uri("http://www.worldskills.com"));
                LoadChange();
            }
            else if(item.Id == 2)
            {
                App.Current.MainPage = new HomePage();
                LoadChange();
            }
            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);

            LoadChange();
        }

        private void LoadChange()
        {
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}