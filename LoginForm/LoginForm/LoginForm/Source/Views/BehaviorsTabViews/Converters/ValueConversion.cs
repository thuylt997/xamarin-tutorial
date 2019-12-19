/**
 * This class contains code to convert SelectedItemEventArgs 
 * to SelectedItem by using IValueConverter
 */

using System;
using System.Globalization;
using Xamarin.Forms;

namespace LoginForm.Source.Views.BehaviorsTabViews.Converters
{
    public class ValueConversion : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectedItemChangedEventArgs;

            return eventArgs.SelectedItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
