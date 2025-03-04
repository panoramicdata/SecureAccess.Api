using Microsoft.Extensions.DependencyInjection;
using SecureAccess.Api.DependencyInjection;

namespace SecureAccess.Api.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSecureAccessApi(this IServiceCollection services)
	{
		// Register the IHttpClientFactory and named HttpClient for OAuth2 operations.
		_ = services.AddHttpClient();
		_ = services.AddHttpClient("OAuth2Client");

		_ = services.AddLogging();

		// Register the SecureAccessClientFactory so you can create clients with runtime options.
		_ = services.AddSingleton<ISecureAccessClientFactory, SecureAccessClientFactory>();

		return services;
	}
}
