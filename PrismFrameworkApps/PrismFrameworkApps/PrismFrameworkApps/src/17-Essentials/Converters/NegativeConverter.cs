using System;
using System.Globalization;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.Converters
{
    public class NegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (value is bool v) ? !v : false;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            (value is bool v) ? !v : true;
    }
}
