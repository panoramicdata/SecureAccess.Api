using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class ApiKey
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = string.Empty;

	[JsonPropertyName("clientId")]
	public string ClientId { get; set; } = string.Empty;

	[JsonPropertyName("creatorKeyId")]
	public string CreatorKeyId { get; set; } = string.Empty;

	[JsonPropertyName("creatorName")]
	public string CreatorName { get; set; } = string.Empty;

	[JsonPropertyName("creatorEmail")]
	public string CreatorEmail { get; set; } = string.Empty;

	[JsonPropertyName("createdAt")]
	public DateTime CreatedAt { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("expireAt")]
	public DateTime? ExpireAt { get; set; }

	[JsonPropertyName("modifiedAt")]
	public DateTime ModifiedAt { get; set; }

	[JsonPropertyName("lastUsedAt")]
	public DateTime? LastUsedAt { get; set; }

	[JsonPropertyName("lastRefreshedAt")]
	public DateTime? LastRefreshedAt { get; set; }

	[JsonPropertyName("scopes")]
	public List<string> Scopes { get; set; } = [];

	[JsonPropertyName("allowedIPs")]
	public List<string> AllowedIPs { get; set; } = [];
}
