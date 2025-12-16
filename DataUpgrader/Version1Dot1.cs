using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataUpgrader
{
    public static class Version1Dot1
    {
        public static string Convert(string xmlInput)
        {
            string regexPattern = @"<Question Number=""(\d+)"">";
            string regexReplacement = @"<Question Name=""Q$1"">";

            return Regex.Replace(xmlInput, regexPattern, regexReplacement, RegexOptions.None);
        }
    }
}
