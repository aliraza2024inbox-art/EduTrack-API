using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
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
        var registerDto = new RegisterDto
        {
            Email = $"user{Guid.NewGuid()}@test.com",
            Password = "Password123!",
            Role = "Student"
        };

        var response = await _client.PostAsJsonAsync(
            "/api/Auth/register",
            registerDto);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Login_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var email = $"user{Guid.NewGuid()}@test.com";

        var registerDto = new RegisterDto
        {
            Email = email,
            Password = "Password123!",
            Role = "Student"
        };

        var registerResponse = await _client.PostAsJsonAsync(
            "/api/Auth/register",
            registerDto);

        registerResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var loginDto = new LoginDto
        {
            Email = email,
            Password = "Password123!"
        };

        // Act
        var loginResponse = await _client.PostAsJsonAsync(
            "/api/Auth/login",
            loginDto);

        // Assert
        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var json = await loginResponse.Content.ReadFromJsonAsync<JsonElement>();

        json.TryGetProperty("token", out var token)
            .Should().BeTrue();

        token.GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Login_ShouldReturnUnauthorized_WhenUserDoesNotExist()
    {
        var loginDto = new LoginDto
        {
            Email = "notfound@test.com",
            Password = "WrongPassword123!"
        };

        var response = await _client.PostAsJsonAsync(
            "/api/Auth/login",
            loginDto);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
    [Fact]
    public async Task Register_Then_Login_ShouldReturnJwtToken()
    {
        // Arrange
        var email = $"user{Guid.NewGuid()}@test.com";

        var registerDto = new RegisterDto
        {
            Email = email,
            Password = "Password123!",
            Role = "Student"
        };

        // Register the user
        var registerResponse = await _client.PostAsJsonAsync(
            "/api/Auth/register",
            registerDto);

        registerResponse.EnsureSuccessStatusCode();

        var loginDto = new LoginDto
        {
            Email = email,
            Password = "Password123!"
        };

        // Act
        var loginResponse = await _client.PostAsJsonAsync(
            "/api/Auth/login",
            loginDto);

        // Assert
        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseBody = await loginResponse.Content.ReadAsStringAsync();

        responseBody.Should().Contain("token");
    }
}
