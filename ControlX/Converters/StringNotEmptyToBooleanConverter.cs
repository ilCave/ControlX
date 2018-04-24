using System;
using System.Globalization;
using Xamarin.Forms;

namespace ControlX.Converters
{
    public class StringNotEmptyToBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is string)) return false;
            return !string.IsNullOrWhiteSpace(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
