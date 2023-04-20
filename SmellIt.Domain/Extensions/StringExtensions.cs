using System.Text.RegularExpressions;

namespace SmellIt.Domain.Extensions;
public static class StringExtensions
{
    public static string ConvertToEncodedName(this string input)
    {
        input = input.ToLowerInvariant();
        
        var allowedCharsPattern = new Regex("[^a-z0-9 ]");
        input = allowedCharsPattern.Replace(input, "");
        
        input = input.Replace(' ', '-');

        input = input.Length > 50 ? input.Substring(0, 50) : input;

		return input;
    }
}