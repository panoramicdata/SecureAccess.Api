using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class ApiKeyListResponse
{
	[JsonPropertyName("message")]
	public string Message { get; set; } = string.Empty;

	[JsonPropertyName("offset")]
	public int Offset { get; set; }

	[JsonPropertyName("limit")]
	public int Limit { get; set; }

	[JsonPropertyName("total")]
	public int Total { get; set; }

	[JsonPropertyName("keys")]
	public List<ApiKey> Keys { get; set; } = [];
}
