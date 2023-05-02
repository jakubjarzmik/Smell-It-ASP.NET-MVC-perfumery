using System.Text;
using System.Text.RegularExpressions;

namespace SmellIt.Domain.Extensions;
public static class StringExtensions
{
    public static string ConvertToEncodedName(this string input)
    {
        string normalized = input.ToLowerInvariant().Normalize(NormalizationForm.FormD);

        StringBuilder text = new StringBuilder();
        foreach (char c in normalized)
        {
            if (char.IsLetterOrDigit(c) || c == ' ' || c == '-')
            {
                text.Append(c);
            }
        }
        string encodedName = text.ToString().Replace(" ", "-");

        return encodedName;
    }
}