using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class AuthResponse
{
	[JsonPropertyName("token_type")]
	public required string TokenType { get; set; }

	[JsonPropertyName("access_token")]
	public required string AccessToken { get; set; }

	[JsonPropertyName("expires_in")]
	public int ExpiresIn { get; set; }
}
