using System.Text.RegularExpressions;

namespace ElectronicTextbook.Infrastructure
{
    internal static class ConsonantChecker
    {
        private const string _pattern = "[бвгджзйклмнпрстфхцчшщ]";

        internal static bool IsStartWithConsonant(string source)
        {
            if (!string.IsNullOrWhiteSpace(source))
            {
                string input = source[0].ToString();
                return Regex.IsMatch(input, _pattern, RegexOptions.IgnoreCase);
            }

            return false;
        }
    }
}
