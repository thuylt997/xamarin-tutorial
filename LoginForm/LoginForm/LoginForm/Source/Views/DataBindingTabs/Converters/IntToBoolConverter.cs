using System;
using System.Globalization;
using Xamarin.Forms;

namespace LoginForm.Source.Views.DataBindingTabs.Converters
{
    /**
     * If the data binding also includes a StringFormat setting, the value converter
     * is invoked before the result is formatted as a string.
     */
    public class IntToBoolConverter : IValueConverter
    {
        /**
         * Data moves from the source to the target in OneWay or TwoWay bindings.
         * The value parameter is the object or value from the data-binding source.
         * The method must return a value of the type of the data-binding target.
         */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (int)value != 0;

        /**
         * Data moves from the target to the source in TwoWay or OneWayToSource bindings.
         * The value parameter is the object or value from the data-binding target.
         * The method must return a value of the type of the data-binding source.
         */
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            //(bool)value ? 1 : 0;
            throw new NotImplementedException();
    }
}
