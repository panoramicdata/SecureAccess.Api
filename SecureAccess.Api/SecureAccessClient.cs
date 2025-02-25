using Microsoft.Extensions.Logging;
using Refit;
using SecureAccess.Api.Sections;
using SecureAccess.Api.Services;
using System.Net.Http.Headers;

namespace SecureAccess.Api;

/// <summary>
/// SecureAccessClient manages authentication and provides access to API endpoints.
/// </summary>
public class SecureAccessClient
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly OAuth2Service _authService;
	private readonly SecureAccessClientOptions _clientOptions;

	/// <summary>
	/// API client for managing API keys.
	/// </summary>
	//public IApiKeyAdmin ApiKeyAdmin { get; }
	public DeploymentsSection Deployments { get; } = new();

	/// <summary>
	/// Initializes SecureAccessClient with required dependencies.
	/// </summary>
	public SecureAccessClient(
		SecureAccessClientOptions clientOptions,
		IHttpClientFactory httpClientFactory,
		ILogger<SecureAccessClient> logger)
	{
		_clientOptions = clientOptions;
		_httpClientFactory = httpClientFactory;

		var authHttpClient = httpClientFactory.CreateClient();
		authHttpClient.BaseAddress = new(clientOptions.ApiUrl);
		_authService = new OAuth2Service(clientOptions, authHttpClient, logger);

		Deployments = new()
		{
			RoamingComputers = RefitFor(Deployments.RoamingComputers)
		};
	}

	/// <summary>
	/// Creates an authenticated HttpClient with automatic token injection.
	/// </summary>
	private HttpClient GetAuthenticatedHttpClient()
	{
		var client = _httpClientFactory.CreateClient();
		client.BaseAddress = new Uri(_clientOptions.ApiUrl);
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authService.GetAccessTokenAsync().Result);

		return client;
	}

	private T RefitFor<T>(T _) => RestService.For<T>(GetAuthenticatedHttpClient());
}
