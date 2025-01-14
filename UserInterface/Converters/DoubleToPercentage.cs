using System.Globalization;
using System.Windows.Data;

namespace UserInterface.Converters
{

    class DoubleToPercentage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double dValue)
            {
                int percentage = (int)(dValue * 100);
                return $"{percentage}%";
            }
            else throw new ArgumentException("Input value must be a double");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
