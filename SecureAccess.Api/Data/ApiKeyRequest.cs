using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class ApiKeyRequest
{
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("scopes")]
	public List<string> Scopes { get; set; } = [];

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("expireAt")]
	public string ExpireAt { get; set; } = string.Empty;

	[JsonPropertyName("allowedIPs")]
	public List<string> AllowedIPs { get; set; } = [];
}
