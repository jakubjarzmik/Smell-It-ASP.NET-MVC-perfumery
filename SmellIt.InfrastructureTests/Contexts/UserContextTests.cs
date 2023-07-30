using System.Security.Claims;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using SmellIt.Infrastructure.Contexts;
using Xunit;

namespace SmellIt.InfrastructureTests.Contexts
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // Arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "test@test.com"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));
            var httpContextAccessor = new Mock<IHttpContextAccessor>();

            httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessor.Object);

            // Act
            var currentUser = userContext.GetCurrentUser();

            // Assert
            currentUser.Should().NotBeNull();
            currentUser!.Id.Should().Be("1");
            currentUser!.Email.Should().Be("test@test.com");
            currentUser!.Roles.Should().Contain("Admin");
        }
    }
}