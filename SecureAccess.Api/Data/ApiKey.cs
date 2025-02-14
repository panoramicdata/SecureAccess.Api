using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class ApiKey
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("clientId")]
	public string ClientId { get; set; }

	[JsonPropertyName("creatorKeyId")]
	public string CreatorKeyId { get; set; }

	[JsonPropertyName("creatorName")]
	public string CreatorName { get; set; }

	[JsonPropertyName("creatorEmail")]
	public string CreatorEmail { get; set; }

	[JsonPropertyName("createdAt")]
	public DateTime CreatedAt { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("expireAt")]
	public DateTime? ExpireAt { get; set; }

	[JsonPropertyName("modifiedAt")]
	public DateTime ModifiedAt { get; set; }

	[JsonPropertyName("lastUsedAt")]
	public DateTime? LastUsedAt { get; set; }

	[JsonPropertyName("lastRefreshedAt")]
	public DateTime? LastRefreshedAt { get; set; }

	[JsonPropertyName("scopes")]
	public List<string> Scopes { get; set; }

	[JsonPropertyName("allowedIPs")]
	public List<string> AllowedIPs { get; set; }
}
