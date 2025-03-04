using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;
using SecureAccess.Api;
using SecureAccess.Api.Data;
using SecureAccess.Api.DependencyInjection;
using SecureAccess.Api.Extensions;

class Program
{
	private const int Deployments_MaxRequestsPerSecond = 5;

	static async Task Main(string[] args)
	{
		// Build a generic host that reads configuration from appsettings.json
		using var host = Host.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((hostingContext, config) =>
				// Ensure appsettings.json is loaded
				config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
			.ConfigureServices((context, services) =>
				// Register your SecureAccess API services (DI for IHttpClientFactory, logging, and your factory)
				_ = services.AddSecureAccessApi())
			.ConfigureLogging(logging =>
			{
				_ = logging.ClearProviders();
				_ = logging.AddConsole();
			})
			.Build();

		// Resolve configuration and logging services
		var configuration = host.Services.GetRequiredService<IConfiguration>();
		var logger = host.Services.GetRequiredService<ILogger<Program>>();

		// Read SecureAccessClientOptions from appsettings.json
		var options = configuration.Get<SecureAccessClientOptions>();
		if (options == null)
		{
			logger.LogError("Unable to load SecureAccessClientOptions from configuration.");
			return;
		}

		// Resolve the SecureAccessClientFactory from DI
		var factory = host.Services.GetRequiredService<ISecureAccessClientFactory>();

		// Create a SecureAccessClient using the runtime options
		var client = factory.CreateClient(options);

		_ = await PerformSingleCallAsync(logger, client, "SingleListRoamingComputers");
		await PerformLoopCallAsync(logger, client, "LoopListRoamingComputers", Deployments_MaxRequestsPerSecond + 1);

		Console.WriteLine("Press any key to exit...");
		_ = Console.ReadKey();

		await host.StopAsync();
	}

	/// <summary>
	/// Makes a single API call to list roaming computers while logging the operation name and attempt number.
	/// </summary>
	private static async Task<ApiResponse<List<RoamingComputer>>> PerformSingleCallAsync(
		ILogger logger,
		SecureAccessClient client,
		string operationName,
		int attempt = 1)
	{
		logger.LogInformation("{OperationName} - Attempt {Attempt}: Making API call...", operationName, attempt);

		var response = await client.Deployments.RoamingComputers.ListRoamingComputers();

		if (response.IsSuccessStatusCode)
		{
			logger.LogInformation("{OperationName} - Attempt {Attempt}: {RoamingComputersCount} results have been returned.",
				operationName, attempt, response.Content?.Count);
		}
		else
		{
			logger.LogWarning("{OperationName} - Attempt {Attempt}: API call failed with status {StatusCode}.",
				operationName, attempt, response.StatusCode);
		}

		return response;
	}

	/// <summary>
	/// Calls PerformSingleCallAsync in a loop for a specified number of attempts.
	/// </summary>
	private static async Task PerformLoopCallAsync(
		ILogger logger,
		SecureAccessClient client,
		string operationName,
		int maxAttempts)
	{
		logger.LogInformation("{OperationName}: Starting {MaxAttempts} attempts...", operationName, maxAttempts);

		for (var attempt = 1; attempt <= maxAttempts; attempt++)
		{
			_ = await PerformSingleCallAsync(logger, client, operationName, attempt);
		}

		logger.LogInformation("{OperationName}: Completed {MaxAttempts} attempts.", operationName, maxAttempts);
	}
}
