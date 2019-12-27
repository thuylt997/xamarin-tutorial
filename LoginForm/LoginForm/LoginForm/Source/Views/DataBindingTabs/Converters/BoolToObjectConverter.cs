using System;
using System.Globalization;
using Xamarin.Forms;

namespace LoginForm.Source.Views.DataBindingTabs.Converters
{
    public class BoolToObjectConverter<T> : IValueConverter
    {
        public T TrueObject { get; set; }

        public T FalseObject { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (bool)value ? TrueObject : FalseObject;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
        //((T)value).Equals(TrueObject);
    }
}
