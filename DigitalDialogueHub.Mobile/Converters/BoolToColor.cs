using System;
using System.Globalization;
using DigitalDialogueHub.Mobile.Converters;
using Microsoft.Maui.Controls;

namespace DigitalDialogueHub.Mobile.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRead = (bool)value;
            return isRead ? Colors.LightGray : Colors.LightYellow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


