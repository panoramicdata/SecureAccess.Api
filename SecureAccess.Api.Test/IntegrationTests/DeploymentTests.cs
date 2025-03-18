using FluentAssertions;
using Refit;
using SecureAccess.Api.Data;
using SecureAccess.Api.Extensions;
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
			.ListRoamingComputersAsync();

		// Assert
		_ = response.IsSuccessful.Should().BeTrue();
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
				.ListRoamingComputersAsync();

			// although rate-limiting will occur, all requests should eventually succeed
			// Assert
			_ = response.IsSuccessful.Should().BeTrue();
		}
	}

	[Fact]
	public async Task ListNetworkTunnelGroups_ReturnsPagedResponse()
	{
		// Arrange
		// Act
		var response = await TestSecureAccessClient
			.Deployments
			.NetworkTunnelGroups
			.ListNetworkTunnelGroupsAsync(includeStatuses: true);

		// Assert
		_ = response.Should().NotBeNull();
		_ = response.Should().BeOfType<PagedResponse<NetworkTunnelGroup>>();
		_ = response.Data.Should().NotBeNullOrEmpty();
		_ = response.Total.Should().BeGreaterThan(0);
	}

	[Fact]
	public async Task ListNetworkTunnelGroupsAll_ReturnsListOfNetworkTunnelGroups()
	{
		// Arrange
		// Act
		var response = await TestSecureAccessClient
			.Deployments
			.NetworkTunnelGroups
			.ListNetworkTunnelGroupsAllAsync(includeStatuses: true);
		// Assert
		_ = response.Should().NotBeNull();
		_ = response.Should().BeOfType<List<NetworkTunnelGroup>>();
		_ = response.Should().NotBeNullOrEmpty();
		_ = response.Count.Should().BeGreaterThan(0);
	}

	[Fact]
	public async Task ListConnectorGroups_ReturnsPagedResponse()
	{
		// Arrange
		// Act
		var response = await TestSecureAccessClient
			.Deployments
			.ConnectorGroups
			.ListConnectorGroupsAsync();
		// Assert
		_ = response.Should().NotBeNull();
		_ = response.Should().BeOfType<PagedResponse<ConnectorGroup>>();
		_ = response.Data.Should().NotBeNullOrEmpty();
		_ = response.Total.Should().BeGreaterThan(0);
	}

	[Fact]
	public async Task ListConnectorGroupsAll_ReturnsListOfConnectorGroups()
	{
		// Arrange
		// Act
		var response = await TestSecureAccessClient
			.Deployments
			.ConnectorGroups
			.ListConnectorGroupsAllAsync();
		// Assert
		_ = response.Should().NotBeNull();
		_ = response.Should().BeOfType<List<ConnectorGroup>>();
		_ = response.Should().NotBeNullOrEmpty();
		_ = response.Count.Should().BeGreaterThan(0);
	}
}
