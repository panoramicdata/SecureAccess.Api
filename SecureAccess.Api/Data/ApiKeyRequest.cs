using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class ApiKeyRequest
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("scopes")]
	public List<string> Scopes { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("expireAt")]
	public string ExpireAt { get; set; }

	[JsonPropertyName("allowedIPs")]
	public List<string> AllowedIPs { get; set; }
}
