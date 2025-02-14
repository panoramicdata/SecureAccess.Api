using FluentAssertions;

namespace SecureAccess.Api.Test;

public class SecureAccessClientTests : IntegrationTestBase
{
	[Fact]
	public async Task GetApiKeys_ShouldReturnKeys_WhenAuthenticated()
	{
		// Act
		var response = await SecureAccessClient.ApiKeyAdmin.GetApiKeys();

		// Assert
		_ = response.IsSuccessStatusCode.Should().BeTrue();
		_ = response.Content.Should().NotBeNull();
		_ = response.Content.Keys.Should().NotBeEmpty();
	}
}

