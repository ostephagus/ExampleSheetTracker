using System.Globalization;
using System.Windows.Data;

namespace UserInterface.Converters
{
    public class DaysAheadToText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int iValue)
            {
                if (iValue == 0) return "On schedule";
                if (iValue > 0) return $"{iValue} day{(iValue == 1 ? "" : "s")} ahead";
                else return $"{-iValue} day{(iValue == -1 ? "" : "s")} behind";
            }
            else throw new ArgumentException("Input value was not an integer.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
