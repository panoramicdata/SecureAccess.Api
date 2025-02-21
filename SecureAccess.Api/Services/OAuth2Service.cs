using Microsoft.Extensions.Logging;
using SecureAccess.Api.Data;
using SecureAccess.Api.Exceptions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SecureAccess.Api.Services;

internal class OAuth2Service(
	SecureAccessClientOptions clientOptions,
	HttpClient httpClient,
	ILogger logger) : IOAuth2Service
{
	private readonly SecureAccessClientOptions _clientOptions = clientOptions;
	private readonly HttpClient _httpClient = httpClient;
	private readonly ILogger _logger = logger;
	private string? _accessToken;
	private DateTime _tokenExpiry;

	/// <summary>
	/// Retrieves a valid access token, refreshing if necessary.
	/// </summary>
	public async Task<string> GetAccessTokenAsync()
		=> _accessToken != null && DateTime.UtcNow < _tokenExpiry
			? _accessToken
			: await RefreshAccessTokenAsync();

	private async Task<string> RefreshAccessTokenAsync()
	{
		try
		{
			// Generate Basic Authentication header value
			var authBytes = Encoding.UTF8.GetBytes($"{_clientOptions.ApiKey}:{_clientOptions.ApiSecret}");
			var body = new Dictionary<string, string>
			{
				{ "grant_type", "client_credentials" }
			};

			// using the auth header to get the access token
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authBytes));
			var response = await _httpClient.PostAsJsonAsync("auth/v2/token", body);

			if (response.IsSuccessStatusCode)
			{
				var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

				if (authResponse != null)
				{
					_accessToken = authResponse.AccessToken;
					_tokenExpiry = DateTime.UtcNow.AddSeconds(authResponse.ExpiresIn - 30); // Buffer time before expiry
					_logger.LogInformation("New access token obtained.");

					return _accessToken;
				}
			}

			var content = await response.Content.ReadAsStringAsync();

			_logger.LogError("Failed to retrieve access token: {StatusCode} : {ResponseContent}", response.StatusCode, content);
			throw new SecureAccessApiException($"Authentication failed {response.StatusCode} : {content}");
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Error retrieving access token.");
			throw;
		}
	}
}
