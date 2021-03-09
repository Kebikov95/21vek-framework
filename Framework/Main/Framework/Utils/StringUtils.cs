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
            string[] typeArray;
            if (text.Contains(separator)) typeArray = text.Split(separator);
            else
            {
                typeArray = new string[1];
                typeArray[0] = text;
            }
            return typeArray;
        }
    }
}
