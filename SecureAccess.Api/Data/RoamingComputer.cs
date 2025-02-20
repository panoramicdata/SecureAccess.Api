using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;
public class RoamingComputer
{
	[JsonPropertyName("deviceId")]
	public string DeviceId { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;

	[JsonPropertyName("swgStatus")]
	public SwqStatus SwgStatus { get; set; }

	[JsonPropertyName("lastSync")]
	public DateTime LastSync { get; set; }

	[JsonPropertyName("createdAt")]
	public DateTime CreatedAt { get; set; }

	[JsonPropertyName("updatedAt")]
	public DateTime UpdatedAt { get; set; }
}
