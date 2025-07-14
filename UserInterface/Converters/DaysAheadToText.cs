using System.Globalization;
using System.Windows.Data;

namespace UserInterface.Converters
{
    [ValueConversion(typeof(int?), typeof(string))]
    public class DaysAheadToText : IValueConverter
    {
        /// <summary>
        /// Converts a number of days ahead to a text representation
        /// </summary>
        /// <param name="value">The number of days ahead, or null if there is no sheet active</param>
        /// <param name="parameter"><see cref="true"/> if the returned string should have parenthesis, <see cref="false"/> if not.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (parameter is bool brackets || bool.TryParse(parameter.ToString(), out brackets))
            {
                if (value is int iValue)
                {
                    string withoutBrackets;
                    if (iValue == 0)
                    {
                        withoutBrackets = "On schedule";
                    }

                    else if (iValue > 0)
                    {
                        withoutBrackets = $"{iValue} day{(iValue == 1 ? "" : "s")} ahead";
                    }
                    else
                    {
                        withoutBrackets = $"{-iValue} day{(iValue == -1 ? "" : "s")} behind";
                    }

                    if (brackets)
                    {
                        return $"({withoutBrackets})";
                    }
                    else return withoutBrackets;
                }

                else if (value is null)
                {
                    if (brackets) return "";
                    else return "On schedule";
                }
                else throw new ArgumentException("Input value was not an integer.");
            }

            else throw new ArgumentException("Converter parameter was not a boolean.");
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
