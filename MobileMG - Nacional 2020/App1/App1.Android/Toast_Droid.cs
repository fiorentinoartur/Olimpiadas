using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(Toast_Droid))]
namespace App1.Droid
{
    public class Toast_Droid : IToast
    {
        public void Show(string text)
        {
           Android.Widget.Toast.MakeText(Android.App.Application.Context,text, ToastLength.Long).Show();
        }
    }
}