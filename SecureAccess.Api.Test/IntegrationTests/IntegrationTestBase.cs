using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Xunit.Abstractions;

namespace SecureAccess.Api.Test.IntegrationTests;
public abstract class IntegrationTestBase
{
	protected readonly SecureAccessClient TestSecureAccessClient;

	protected readonly ILogger<SecureAccessClient> Logger;
	private readonly ServiceProvider _serviceProvider;

	public IntegrationTestBase(ITestOutputHelper testOutputHelper)
	{
		// Load test configuration
		var testClientOptions = JsonSerializer.Deserialize<SecureAccessClientOptions>(
			File.ReadAllText("../../../appsettings.json"))
			?? throw new InvalidDataException("Test config is empty");

		var secureAccessClientOptions = new SecureAccessClientOptions
		{
			ApiUrl = testClientOptions.ApiUrl,
			ApiKey = testClientOptions.ApiKey,
			ApiSecret = testClientOptions.ApiSecret,
			KeyAdminApiKey = testClientOptions.KeyAdminApiKey,
			KeyAdminApiSecret = testClientOptions.KeyAdminApiSecret
		};

		// Set up a minimal DI container for the integration tests
		var services = new ServiceCollection();
		_ = services.AddHttpClient();  // This registers IHttpClientFactory

		_serviceProvider = services.BuildServiceProvider();
		var httpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>();

		// Build a logger for SecureAccessClient using the test output helper
		Logger = testOutputHelper.BuildLoggerFor<SecureAccessClient>();
		TestSecureAccessClient = new SecureAccessClient(secureAccessClientOptions, httpClientFactory, Logger);
	}

	public void Dispose() => _serviceProvider?.Dispose();
}

