using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using SecureAccess.Api.Interfaces;
using SecureAccess.Api.Sections;
using SecureAccess.Api.Services;
using System.Net.Http.Headers;

namespace SecureAccess.Api;

/// <summary>
/// SecureAccessClient manages authentication and provides access to API endpoints.
/// </summary>
public class SecureAccessClient
{
	private readonly ILogger<SecureAccessClient> _logger;
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly IServiceProvider _serviceProvider;
	private readonly OAuth2Service _authService;
	private readonly SecureClientOptions _clientOptions;

	/// <summary>
	/// API client for managing API keys.
	/// </summary>
	public IApiKeyAdmin ApiKeyAdmin { get; }
	public DeploymentsSection Deployments { get; } = new();

	/// <summary>
	/// Initializes SecureAccessClient with required dependencies.
	/// </summary>
	public SecureAccessClient(
		SecureClientOptions clientOptions,
		ILogger<SecureAccessClient> logger)
	{
		_httpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>();
		_logger = _serviceProvider.GetRequiredService<ILogger<SecureAccessClient>>();
		_authService = new OAuth2Service(clientOptions, _httpClientFactory.CreateClient(), logger);

		Deployments = new()
		{
			RoamingComputers = RefitFor(Deployments.RoamingComputers)
		};
		_clientOptions = clientOptions;
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
