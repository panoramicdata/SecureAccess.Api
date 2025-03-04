using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using SecureAccess.Api;
using SecureAccess.Api.Authentication;
using SecureAccess.Api.DependencyInjection;
using SecureAccess.Api.Services;
using System.Net;

public class SecureAccessClientFactory(
	IHttpClientFactory httpClientFactory,
	ILoggerFactory loggerFactory) : ISecureAccessClientFactory
{

	private const int HttpStatusCode_TooManyRequests = 429;

	private readonly ILoggerFactory _loggerFactory = loggerFactory;

	public SecureAccessClient CreateClient(SecureAccessClientOptions options)
	{
		// Create the OAuth2Service manually using runtime options.
		var oauthLogger = _loggerFactory.CreateLogger<OAuth2Service>();
		var oauthService = new OAuth2Service(options, httpClientFactory, oauthLogger);

		var logger = _loggerFactory.CreateLogger<SecureAccessClient>();
		var httpClient = GetHttpClientWithAuthAndRetryPolicy(options, oauthService, logger);

		return new SecureAccessClient(options, httpClient, logger);
	}

	private static HttpClient GetHttpClientWithAuthAndRetryPolicy(SecureAccessClientOptions options, OAuth2Service oauthService, ILogger<SecureAccessClient> logger)
	{
		// Create the AuthenticationHandler with the runtime OAuth2Service.
		var authHandler = new AuthenticationHandler(oauthService)
		{
			InnerHandler = new HttpClientHandler()
		};

		var policyHandler = new PolicyHttpMessageHandler(GetRetryPolicy(logger))
		{
			InnerHandler = authHandler
		};

		var httpClient = new HttpClient(policyHandler)
		{
			BaseAddress = new Uri(options.ApiUrl)
		};
		return httpClient;
	}

	private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy(ILogger<SecureAccessClient> logger)
		=> HttpPolicyExtensions
			.HandleTransientHttpError()
			.OrResult(msg => msg.StatusCode == (HttpStatusCode)HttpStatusCode_TooManyRequests)
			.WaitAndRetryAsync(
				retryCount: 2,
		sleepDurationProvider: (retryAttempt, outcome, context)
			=> outcome.Result != null &&
					outcome.Result.Headers.TryGetValues("Retry-After", out var values) &&
					int.TryParse(values.FirstOrDefault(), out var seconds)
					? TimeSpan.FromSeconds(seconds)
					: TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
		onRetryAsync: (outcome, timespan, retryAttempt, context)
			=>
		{
			logger.LogWarning("Request failed with {StatusCode}. Retrying attempt {RetryAttempt} in {Delay} seconds.",
						outcome.Result?.StatusCode, retryAttempt, timespan.TotalSeconds);

			return Task.CompletedTask;
		});
}
