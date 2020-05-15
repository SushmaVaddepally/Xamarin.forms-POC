namespace GamesZone.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class NullToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSTQaaGxVT4EB_BgS8BGOhc4PVrQ2nBmz-48qMq4EzFPSrJnIMg";
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSTQaaGxVT4EB_BgS8BGOhc4PVrQ2nBmz-48qMq4EzFPSrJnIMg";
            }
            else
            {
                return value;
            }
        }
    }
}
