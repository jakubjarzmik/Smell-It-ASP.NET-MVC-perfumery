using FluentAssertions;
using SmellIt.Domain.Extensions;
using Xunit;

namespace SmellIt.DomainTests.Extensions;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("Name - string to convert", "name---string-to-convert")]
    [InlineData("My 1st text with (*&%^#", "my-1st-text-with")]
    [InlineData("123", "123")]
    public void ConvertToEncodedName_ForStringName_ReturnsEncodedName(string name, string expectedEncodedName)
    {
        // Arrange

        // Act
        string actualEncodedName = name.ConvertToEncodedName();

        // Assert
        actualEncodedName.Should().Be(expectedEncodedName);
    }
}