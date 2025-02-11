using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public enum AuthGrantType
{
	Unknown = 0,
	[JsonPropertyName("client_credentials")]
	ClientCredentials = 1,
}