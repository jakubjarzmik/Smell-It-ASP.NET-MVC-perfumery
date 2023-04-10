using System.Text.RegularExpressions;

namespace SmellIt.Application.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertNameToKey(this string input)
        {
            string withoutWhitespace = Regex.Replace(input, @"\s+", " ");
            string[] words = withoutWhitespace.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
                }
            }

            return string.Concat(words);
        }
    }
}
