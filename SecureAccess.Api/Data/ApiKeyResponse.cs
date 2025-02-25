using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class ApiKeyResponse
{
	[JsonPropertyName("message")]
	public string Message { get; set; } = string.Empty;

	[JsonPropertyName("key")]
	public ApiKey? Key { get; set; }
}
