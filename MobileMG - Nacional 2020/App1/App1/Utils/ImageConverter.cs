using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App1.Utils
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           var text = value.ToString();
            text = text.Split('.')[0];
            if (text == "default")
                return ImageSource.FromResource($"App1.Images.{text}.png");
            return ImageSource.FromResource($"App1.Images.{text}.jpg");        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
