using System.Net;
using FluentAssertions;
using Xunit;

namespace EduTrack.Tests.Integration;

public class HealthCheckTests : IClassFixture<CustomWebApplicationFactory>
{
	private readonly HttpClient _client;

	public HealthCheckTests(CustomWebApplicationFactory factory)
	{
		_client = factory.CreateClient();
	}

	[Fact]
	public async Task Swagger_ShouldBeAvailable()
	{
		// Act
		var response = await _client.GetAsync("/swagger/index.html");

		// Assert
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}
}