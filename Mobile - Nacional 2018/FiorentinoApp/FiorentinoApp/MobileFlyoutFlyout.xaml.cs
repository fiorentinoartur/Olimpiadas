using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FiorentinoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MobileFlyoutFlyout : ContentPage
    {
        public ListView ListView;

        public MobileFlyoutFlyout()
        {
            InitializeComponent();

            BindingContext = new MobileFlyoutFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            userName.Text = UserDados.usuario.Nome;
            userEmail.Text = UserDados.usuario.Email;
        }
        private class MobileFlyoutFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MobileFlyoutFlyoutMenuItem> MenuItems { get; set; }

            public MobileFlyoutFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MobileFlyoutFlyoutMenuItem>(new[]
                {
                    new MobileFlyoutFlyoutMenuItem { Id = 0, Title = "Contato" },
                    new MobileFlyoutFlyoutMenuItem { Id = 1, Title = "Nosso site" },
                    new MobileFlyoutFlyoutMenuItem { Id = 2, Title = "Sair" },

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            datePicker.Focus();
        }
    }
}
