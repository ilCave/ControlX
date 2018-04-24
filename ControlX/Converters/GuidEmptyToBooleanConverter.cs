using System;
using Xamarin.Forms;

namespace ControlX.Converters
{
    public class GuidEmptyToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            
            if (!(value is string) && !(value is Guid)) return false;
            try
            {
                Guid guid = new Guid(value.ToString());
                return Guid.Equals(guid, Guid.Empty);
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            bool valore = (bool)value;
            return valore?string.Empty:Guid.NewGuid().ToString();
        }
    }
}
