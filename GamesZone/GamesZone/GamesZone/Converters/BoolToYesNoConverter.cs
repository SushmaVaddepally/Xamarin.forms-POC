namespace GamesZone.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class BoolToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool data = (bool)value;
            return data ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool data = (bool)value;
            return data ? "No" : "Yes";
        }
    }
}
