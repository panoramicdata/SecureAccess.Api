using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class AuthRequest
{
	[JsonPropertyName("grant_type")]
	public AuthGrantType GrantType { get; set; } = AuthGrantType.ClientCredentials;
}
