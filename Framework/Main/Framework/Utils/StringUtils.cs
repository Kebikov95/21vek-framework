using System.Text.RegularExpressions;

namespace AutomationFramework.Main.Framework.Utils
{
    class StringUtils
    {
        public static string GetStringWithoutLetters(string line)
        {
            return Regex.Replace(line, "[^0-9,-]+", "");
        }

        public static string[] SplitStringToArray(string text, char separator = ',')
        {
            return text.Split(new[] { separator }, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
