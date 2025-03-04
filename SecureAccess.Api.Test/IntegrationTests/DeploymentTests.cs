using FluentAssertions;
using Refit;
using SecureAccess.Api.Data;
using Xunit.Abstractions;

namespace SecureAccess.Api.Test.IntegrationTests;
public class DeploymentTests(ITestOutputHelper testOutputHelper) : IntegrationTestBase(testOutputHelper)
{
	[Fact]
	public async Task GetRoamingComputers_ShouldReturnComputers_WhenAuthenticated()
	{
		// Arrange
		// Act
		var response = await TestSecureAccessClient
			.Deployments
			.RoamingComputers
			.ListRoamingComputers();

		// Assert
		_ = response.IsSuccessStatusCode.Should().BeTrue();
		_ = response.Content.Should().NotBeNull();
	}

	[Fact]
	public async Task ListRoamingComputers_RetryLogic_Should_HandleRateLimiting()
	{
		// Arrange
		const int maxAttempts = 50;
		var attempt = 0;
		var rateLimitedEncountered = false;
		ApiResponse<List<RoamingComputer>>? response;

		// Act: repeatedly call ListRoamingComputers until a 429 is returned or until maxAttempts.
		do
		{
			attempt++;
			response = await TestSecureAccessClient.Deployments.RoamingComputers.ListRoamingComputers();
			if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
			{
				rateLimitedEncountered = true;
				break;
			}
		}
		while (attempt < maxAttempts);

		// Assert that rate limiting was encountered.
		_ = rateLimitedEncountered.Should().BeTrue("the API should eventually return a 429 response when called repeatedly.");

		// Optionally: wait a short period to allow the retry logic (using the Retry-After header) to kick in.
		// Then perform another call, which should succeed thanks to the Polly retry policy.
		var finalResponse = await TestSecureAccessClient.Deployments.RoamingComputers.ListRoamingComputers();
		_ = finalResponse.IsSuccessStatusCode.Should().BeTrue("the retry policy should eventually allow a successful call after rate limiting.");
	}
}
