using System.Text.RegularExpressions;

namespace ElectronicTextbook.Infrastructure
{
    internal class ConsonantChecker
    {
        internal bool IsStartWithConsonant(string source)
        {
            if (!string.IsNullOrWhiteSpace(source))
            {
                string pattern = "[бвгджзйклмнпрстфхцчшщ]";
                string input = source[0].ToString();

                return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
            }

            return false;
        }
    }
}
