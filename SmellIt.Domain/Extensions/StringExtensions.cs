using System.Text;

namespace SmellIt.Domain.Extensions;
public static class StringExtensions
{
    public static string ConvertToEncodedName(this string input)
    {
        if(string.IsNullOrEmpty(input))
            throw new ArgumentNullException("input");

        string normalized = input.ToLowerInvariant().Normalize(NormalizationForm.FormD);

        StringBuilder text = new StringBuilder();
        foreach (char c in normalized)
        {
            if (char.IsLetterOrDigit(c) || c == ' ' || c == '-')
            {
                text.Append(c);
            }
        }
        
        string encodedName = text.ToString().Trim().Replace(" ", "-");

        return encodedName;
    }
}