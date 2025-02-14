using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SecureAccess.Api.Interfaces;
using System.Text;

namespace SecureAccess.Api.Services;

public class OAuth2Service(
	IAuth authApi,
	IConfiguration configuration,
	ILogger<OAuth2Service> logger)
{
	private readonly IAuth _authApi = authApi;
	private readonly ILogger<OAuth2Service> _logger = logger;
	private readonly string _username = configuration["SecureAccess:Username"] ?? throw new InvalidOperationException("SecureAccess:Username must be set in configuration.");
	private readonly string _password = configuration["SecureAccess:Password"] ?? throw new InvalidOperationException("SecureAccess:Password must be set in configuration.");
	private string _accessToken;
	private DateTime _tokenExpiry;

	/// <summary>
	/// Retrieves a valid access token, refreshing if necessary.
	/// </summary>
	public async Task<string> GetAccessTokenAsync()
		=> IsValidAccessTokenPresent()
			? _accessToken
			: await RefreshAccessTokenAsync();
	private bool IsValidAccessTokenPresent() => _accessToken != null && DateTime.UtcNow < _tokenExpiry;

	private async Task<string> RefreshAccessTokenAsync()
	{
		try
		{
			// Generate Basic Authentication header value
			var authString = $"{_username}:{_password}";
			var authBytes = Encoding.UTF8.GetBytes(authString);
			var authHeader = "Basic " + Convert.ToBase64String(authBytes);

			var response = await _authApi.GetAuthToken(authHeader);


			if (response.IsSuccessStatusCode)
			{
				_accessToken = response.Content.AccessToken;
				_tokenExpiry = DateTime.UtcNow.AddSeconds(response.Content.ExpiresIn - 30); // Buffer time before expiry

				_logger.LogInformation("New access token obtained.");
				return _accessToken;
			}

			_logger.LogError($"Failed to retrieve access token: {response.StatusCode}");
			throw new Exception("Authentication failed");
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Error retrieving access token.");
			throw;
		}
	}
}
