using System;
using System.Collections.Generic;
using System.ComponentModel;
using wsTower.Models;
using wsTower.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wsTower.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}