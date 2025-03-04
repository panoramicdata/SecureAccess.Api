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
		const int maxAttempts = 10;
		ApiResponse<List<RoamingComputer>>? response;

		// Act
		for (var attempt = 1; attempt <= maxAttempts; attempt++)
		{
			response = await TestSecureAccessClient
				.Deployments
				.RoamingComputers
				.ListRoamingComputers();

			// although rate-limiting will occur, all requests should eventually succeed
			// Assert
			_ = response.IsSuccessStatusCode.Should().BeTrue();
		}
	}
}
