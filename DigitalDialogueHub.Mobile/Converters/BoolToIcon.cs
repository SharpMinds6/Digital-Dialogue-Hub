using System;
using System.Globalization;
using DigitalDialogueHub.Mobile.Converters;
using Microsoft.Maui.Controls;

namespace DigitalDialogueHub.Mobile.Converters
{
    public class BoolToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRead = (bool)value;
            return isRead ? "read_icon.png" : "unread_icon.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}



