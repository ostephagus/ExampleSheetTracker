using DataManager;
using System.Globalization;
using System.Windows.Data;

namespace UserInterface.Converters
{
    class ProgressToString : IValueConverter
    {
        /// <summary>
        /// Converts an enum name to a string that can be displayed. For example, converts <see cref="Progress.ToWriteUp"/> to "To write up".
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Progress progress)
            {
                string enumName = Enum.GetName(typeof(Progress), progress) ?? "";
                string plainName = "";
                plainName += enumName[0];
                for (int index = 1; index < enumName.Length; index++)
                {
                    if (char.IsLower(enumName[index]))
                    {
                        plainName += enumName[index];
                    }
                    else if (char.IsUpper(enumName[index]))
                    {
                        plainName += $" {char.ToLower(enumName[index])}"; // add space and lowercase letter
                    }
                }
                return plainName;
            }
            else throw new ArgumentException("Enum type not supported by this converter.");
        }

        /// <summary>
        /// Converts a string of a displayed version of an enum name back to the enum item.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string plainName)
            {
                string enumName = "";
                enumName += plainName[0];
                for (int index = 1; index < plainName.Length; index++)
                {
                    if (plainName[index] == ' ')
                    {
                        index++; // Skip the space
                        enumName += char.ToUpper(plainName[index]); // Uppercase the next letter
                    }
                    else
                    {
                        enumName += plainName[index];
                    }
                }
                return Enum.Parse(typeof(Progress), enumName);
            }
            else throw new ArgumentException("Input value must be a string");
        }
    }
}
