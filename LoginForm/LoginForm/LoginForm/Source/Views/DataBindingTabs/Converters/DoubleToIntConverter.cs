using System;
using System.Globalization;
using Xamarin.Forms;

namespace LoginForm.Source.Views.DataBindingTabs.Converters
{
    public class DoubleToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (int)Math.Round((double)value * GetParameter(parameter));

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            (int)value / GetParameter(parameter);

        double GetParameter(object parameter)
        {
            if (parameter is double)
            {
                return (double)parameter;
            }
            else if (parameter is int)
            {
                return (int)parameter;
            }
            else if (parameter is string)
            {
                return double.Parse((string)parameter);
            }

            return 1;
        }
    }
}
