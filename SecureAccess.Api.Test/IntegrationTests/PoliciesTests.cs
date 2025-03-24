using FluentAssertions;
using SecureAccess.Api.Data;
using SecureAccess.Api.Extensions;
using Xunit.Abstractions;

namespace SecureAccess.Api.Test.IntegrationTests;

public class PoliciesTests(ITestOutputHelper testOutputHelper) : IntegrationTestBase(testOutputHelper)
{
	[Fact]
	public async Task GetDestinationLists_ReturnsPagedResponse()
	{
		// Arrange
		// Act
		var response = await TestSecureAccessClient
			.Policies
			.DestinationLists
			.GetDestinationListsAsync();

		// Assert
		_ = response.Should().NotBeNull();
		_ = response.Should().BeOfType<PagedResponseWithMeta<DestinationList>>();
		_ = response.Meta.Should().NotBeNull();
		_ = response.Meta.Page.Should().Be(1);
		_ = response.Data.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDestinationListsAll_ReturnsAllDestinationLists()
	{
		// Arrange
		// Act
		var response = await TestSecureAccessClient
			.Policies
			.DestinationLists
			.GetDestinationListsAllAsync();

		// Assert
		_ = response.Should().NotBeNull();
		_ = response.Should().BeOfType<List<DestinationList>>();
		_ = response.Should().NotBeEmpty();
	}
}
