namespace GamesZone.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    
    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool data = (bool) value;
            return data ? "Active" : "In Active";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool data = (bool)value;
            return data ? "In Active" : "Active";
        }
    }
}
