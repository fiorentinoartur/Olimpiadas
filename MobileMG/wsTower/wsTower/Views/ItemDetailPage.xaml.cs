using System.ComponentModel;
using wsTower.ViewModels;
using Xamarin.Forms;

namespace wsTower.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}