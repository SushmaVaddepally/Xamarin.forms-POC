namespace GamesZone.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class NullToHiphenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "-";
            }
            else
            {
                var data = (string)value;
                if (data.Equals(""))
                {
                    return "-";
                }
                else
                {
                    return data;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (string)value;
            if (data.Equals(""))
            {
                return data;
            }
            else
            {
                return "-";
            }
        }
    }
}
