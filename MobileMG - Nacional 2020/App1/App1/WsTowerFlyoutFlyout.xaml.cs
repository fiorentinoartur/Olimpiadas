using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WsTowerFlyoutFlyout : ContentPage
    {
        public ListView ListView;

        public WsTowerFlyoutFlyout()
        {
            InitializeComponent();

            BindingContext = new WsTowerFlyoutFlyoutViewModel();
 
            ListView = MenuItemsListView;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            nome.Text = UserDados.Usuario.nome;
            email.Text = UserDados.Usuario.email;
        }

        class WsTowerFlyoutFlyoutViewModel : INotifyPropertyChanged
        {
     
            public ObservableCollection<WsTowerFlyoutFlyoutMenuItem> MenuItems { get; set; }
            
            public WsTowerFlyoutFlyoutViewModel()
            {
              
                MenuItems = new ObservableCollection<WsTowerFlyoutFlyoutMenuItem>(new[]
                {
                    new WsTowerFlyoutFlyoutMenuItem { Id = 0, Title = "Home" , IconSource= "home",Enable = true,  },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 1, Title = "Reportar Ação",IconSource= "add",Enable = true,  },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 2, Title = "Visualizar",IconSource="visu", Enable = UserDados.Usuario.funcaoid == 1 ? true : false},
                    new WsTowerFlyoutFlyoutMenuItem { Id = 3, Title = "Sair",IconSource="sair",Enable = true }
                 
                   
                   
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
    }
}