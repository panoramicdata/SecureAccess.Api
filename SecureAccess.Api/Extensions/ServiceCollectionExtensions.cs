using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Refit;
using SecureAccess.Api.Authentication;
using SecureAccess.Api.Interfaces;
using SecureAccess.Api.Services;

namespace SecureAccess.Api.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSecureAccessApi(this IServiceCollection services, IConfiguration configuration)
	{
		_ = services.AddHttpClient();

		// Register OAuth2Service with configuration
		_ = services.AddSingleton(provider =>
				new OAuth2Service(
					provider.GetRequiredService<IAuth>(),
					configuration,
					provider.GetRequiredService<ILogger<OAuth2Service>>()
				));

		_ = services.AddSingleton<SecureAccessClient>();

		_ = services.AddTransient<AuthenticationHandler>();

		// Refit Interface for Auth API
		_ = services.AddRefitClient<IAuth>()
				// TODO : remove the AuthUrl from the configuration, the IAuth interface should handle the base URL
				.ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["SecureAccess:AuthUrl"]))
				.AddPolicyHandler(GetRetryPolicy());

		// Refit Interface for API Key Admin
		_ = services.AddRefitClient<IApiKeyAdmin>()
				.ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["SecureAccess:BaseUrl"]))
				.AddHttpMessageHandler<AuthenticationHandler>()
				.AddPolicyHandler(GetRetryPolicy());

		return services;
	}

	/// <summary>
	/// Defines a retry policy with exponential backoff.
	/// </summary>
	private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
		=> HttpPolicyExtensions
			.HandleTransientHttpError()
			.OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests) // Handle rate limits
			.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}
