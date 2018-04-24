using System;
using Xamarin.Forms;

namespace ControlX.Converters
{
    public class InverseGuidEmptyToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Guid))
                throw new InvalidOperationException("The target must be a guid");
            return Guid.Equals((Guid)value, Guid.Empty);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
