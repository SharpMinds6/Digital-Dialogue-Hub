using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace DigitalDialogueHub.Mobile.Converters
{
    public class SelectedCategoryBgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Color.FromArgb("#D6ECFA") : Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
