using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Refit;
using SecureAccess.Api.Authentication;
using SecureAccess.Api.Interfaces;
using System.Net;

namespace SecureAccess.Api.Extensions;

public static class ServiceCollectionExtensions
{
	private const int HttpStatusCode_TooManyRequests = 429;

	public static IServiceCollection AddSecureAccessApi(this IServiceCollection services, IConfiguration configuration)
	{
		_ = services.AddHttpClient();

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
			.OrResult(msg => msg.StatusCode == (HttpStatusCode)HttpStatusCode_TooManyRequests) // Handle rate limits
			.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}
