using FluentAssertions;
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
}
