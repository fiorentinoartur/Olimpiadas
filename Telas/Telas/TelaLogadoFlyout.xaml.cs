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

namespace Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaLogadoFlyout : ContentPage
    {
        public ListView ListView;

        public TelaLogadoFlyout()
        {
            InitializeComponent();

            BindingContext = new TelaLogadoFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class TelaLogadoFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TelaLogadoFlyoutMenuItem> MenuItems { get; set; }

            public TelaLogadoFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<TelaLogadoFlyoutMenuItem>(new[]
                {
                    new TelaLogadoFlyoutMenuItem { Id = 0, Title = "Ranking" , TargetType = typeof(RankingPage)},
                    new TelaLogadoFlyoutMenuItem { Id = 0, Title = "About" , TargetType = typeof(AboutPage)},
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