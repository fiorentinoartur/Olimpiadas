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
                MenuItems = new ObservableCollection<WsTowerFlyoutFlyoutMenuItem>(new[]
                {
                    new WsTowerFlyoutFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new WsTowerFlyoutFlyoutMenuItem { Id = 4, Title = "Page 5" },
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