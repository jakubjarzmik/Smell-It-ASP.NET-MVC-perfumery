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

        return input;
    }
}