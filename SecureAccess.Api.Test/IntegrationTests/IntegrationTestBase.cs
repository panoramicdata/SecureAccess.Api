using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SecureAccess.Api.DependencyInjection;
using SecureAccess.Api.Extensions;
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
		// Load test configuration from appsettings.json
		var testClientOptions = JsonSerializer.Deserialize<SecureAccessClientOptions>(
			File.ReadAllText("../../../appsettings.json"))
			?? throw new InvalidDataException("Test config is empty");

		// Set up a DI container.
		var services = new ServiceCollection();

		// Register logging (you may use your own test logger integration).
		_ = services.AddLogging(builder =>
		{
			// Optionally add providers that output to xUnit via ITestOutputHelper.
			// builder.AddXunit(testOutputHelper); // if you have an Xunit logging provider.
		});

		_ = services.AddSecureAccessApi();
		_serviceProvider = services.BuildServiceProvider();

		// Build a logger for SecureAccessClient using your test output helper.
		Logger = testOutputHelper.BuildLoggerFor<SecureAccessClient>();

		// Resolve the factory and create a SecureAccessClient using your test-specific options.
		var factory = _serviceProvider.GetRequiredService<ISecureAccessClientFactory>();
		TestSecureAccessClient = factory.CreateClient(testClientOptions);
	}

	public void Dispose()
	{
		if (_serviceProvider is IDisposable disposable)
		{
			disposable.Dispose();
		}
	}
}

