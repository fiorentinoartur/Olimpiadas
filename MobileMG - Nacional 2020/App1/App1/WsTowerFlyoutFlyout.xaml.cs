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

        class WsTowerFlyoutFlyoutViewModel : INotifyPropertyChanged
        {
     
            public ObservableCollection<WsTowerFlyoutFlyoutMenuItem> MenuItems { get; set; }
            
            public WsTowerFlyoutFlyoutViewModel()
            {
                var usuario = UserDados.Usuario;

                bool isAdmin = usuario != null && usuario.funcaoid == 1;
                MenuItems = new ObservableCollection<WsTowerFlyoutFlyoutMenuItem>(new[]
                {
                    new WsTowerFlyoutFlyoutMenuItem { Id = 0, Title = "Home" , Imagem= "baseline_home_black_24", TargetType= typeof(WsTowerFlyoutDetail) },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 1, Title = "Reportar Ação",Imagem= "baseline_exit_to_app_black_24", TargetType = typeof(ActionReport) },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 2, Title = "Visualizar",Imagem="baseline_pageview_black_24", TargetType = typeof(NewsView) , isEnable = isAdmin},
                    new WsTowerFlyoutFlyoutMenuItem { Id = 3, Title = "Sair",Imagem="baseline_exit_to_app_black_24",TargetType= typeof(LoginPage)},
                 
                   
                   
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