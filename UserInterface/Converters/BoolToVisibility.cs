using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UserInterface.Converters
{
    /// <summary>
    /// Converts from a boolean to either visible or collapsed visibility.
    /// </summary>
    class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool bValue)
            {
                return bValue ? Visibility.Visible : Visibility.Collapsed;
            }
            else throw new InvalidOperationException("Value must be a boolean");
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }
            else throw new InvalidOperationException("Value must be one of Visibility enum");
        }
    }
}
