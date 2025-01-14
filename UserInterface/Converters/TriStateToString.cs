using DataManager;
using System.Globalization;
using System.Windows.Data;

namespace UserInterface.Converters
{
    class TriStateToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TriState triStateObject)
            {
                return triStateObject switch
                {
                    TriState.No => "No",
                    TriState.Maybe => "Maybe",
                    TriState.Yes => "Yes",
                    _ => ""
                };
            }
            else throw new ArgumentException("Input value must be a TriState");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string triStateString)
            {
                return triStateString.ToLower() switch
                {
                    "maybe" => TriState.Maybe,
                    "yes" => TriState.Yes,
                    _ => TriState.No
                };
            }
            else throw new ArgumentException("Input value must be a string");
        }
    }
}
