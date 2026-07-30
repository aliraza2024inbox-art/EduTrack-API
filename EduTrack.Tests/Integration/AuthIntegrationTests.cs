using System.Net;
using System.Net.Http.Json;
using EduTrack.Api.Models.DTOs.Auth;
using FluentAssertions;
using Xunit;

namespace EduTrack.Tests.Integration;

public class AuthIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public AuthIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Register_ShouldReturnSuccess()
    {
        // Arrange
        var request = new RegisterDto
        {
            Email = "integration@test.com",
            Password = "Password123!",
            Role = "Student"
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/Auth/register",
            request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}