using FluentAssertions;
using SmellIt.Domain.Models;
using Xunit;

namespace SmellIt.DomainTests.Models;

public class CurrentUserTests
{
    [Fact]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue()
    {
        // Arrange
        var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin" });

        // Act
        var isInRole = currentUser.IsInRole("Admin");

        // Assert
        isInRole.Should().BeTrue();
    }

    [Fact]
    public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
    {
        // Arrange
        var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin" });

        // Act
        var isInRole = currentUser.IsInRole("Employee");

        // Assert
        isInRole.Should().BeFalse();
    }

    [Fact]
    public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
    {
        // Arrange
        var currentUser = new CurrentUser("1", "test@test.com", new List<string> { "Admin" });

        // Act
        var isInRole = currentUser.IsInRole("admin");

        // Assert
        isInRole.Should().BeFalse();
    }
}