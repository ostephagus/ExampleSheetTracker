using System.Globalization;
using System.Windows.Data;
using DataManager;

namespace UserInterface.Converters
{
    class ProgressEnumToStrings : IValueConverter
    {
        ProgressToString progressToStringConverter = new ProgressToString();

        /// <summary>
        /// Converts a list of enum names to a list of strings that can be displayed. For example, converts <see cref="Progress.ToWriteUp"/> to "To write up".
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Progress[] enumValues)
            {
                string[] names = new string[enumValues.Length];
                for (int i = 0; i < enumValues.Length; i++)
                {
                    Progress enumValue = enumValues[i];
                    names[i] = (string)progressToStringConverter.Convert(enumValue, targetType, parameter, culture);
                }
                return names;
            }
            else throw new ArgumentException("Enum type not supported by this converter.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
