using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SecureAccess.Api.Extensions;

namespace SecureAccess.Api.Test;
public class IntegrationTestBase : IDisposable
{
	protected readonly IServiceProvider ServiceProvider;
	protected readonly SecureAccessClient SecureAccessClient;

	public IntegrationTestBase()
	{
		// Load test configuration
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.Build();

		var services = new ServiceCollection()
			.AddLogging(builder => builder.AddConsole())
			.AddSecureAccessApi(configuration)
			.BuildServiceProvider();

		ServiceProvider = services;
		SecureAccessClient = ServiceProvider.GetRequiredService<SecureAccessClient>();
	}

	public void Dispose()
	{
		// Clean up resources if needed
	}
}

