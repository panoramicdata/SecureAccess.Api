using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using SecureAccess.Api.Interfaces;
using SecureAccess.Api.Services;

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
	private readonly string _baseUrl = "https://api.sse.cisco.com/admin/v2";

	/// <summary>
	/// API client for managing API keys.
	/// </summary>
	public IApiKeyAdmin ApiKeyAdmin { get; }

	/// <summary>
	/// Initializes SecureAccessClient with required dependencies.
	/// </summary>
	public SecureAccessClient(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
		_httpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>();
		_logger = _serviceProvider.GetRequiredService<ILogger<SecureAccessClient>>();
		_authService = _serviceProvider.GetRequiredService<OAuth2Service>();

		var httpClient = CreateAuthenticatedHttpClient();
		ApiKeyAdmin = RestService.For<IApiKeyAdmin>(httpClient);
	}

	/// <summary>
	/// Creates an authenticated HttpClient with automatic token injection.
	/// </summary>
	private HttpClient CreateAuthenticatedHttpClient()
	{
		var client = _httpClientFactory.CreateClient();
		client.BaseAddress = new Uri(_baseUrl);

		client.DefaultRequestHeaders.Authorization =
			new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authService.GetAccessTokenAsync().Result);

		return client;
	}
}
