using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;
public class RoamingComputer
{
	[JsonPropertyName("originId")]
	public long OriginId { get; set; }


	[JsonPropertyName("deviceId")]
	public string DeviceId { get; set; } = string.Empty;

	[JsonPropertyName("type")]
	public string Type { get; set; } = string.Empty;

	// TODO: add enum for Status
	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;

	[JsonPropertyName("lastSyncStatus")]
	public string LastSyncStatus { get; set; } = string.Empty;

	[JsonPropertyName("lastSync")]
	public DateTime LastSync { get; set; }

	[JsonPropertyName("version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("hasIpBlocking")]
	public bool HasIpBlocking { get; set; }

	[JsonPropertyName("appliedBundle")]
	public int AppliedBundle { get; set; }

	[JsonPropertyName("osVersion")]
	public string OsVersion { get; set; } = string.Empty;

	[JsonPropertyName("osVersionName")]
	public string OsVersionName { get; set; } = string.Empty;

	[JsonPropertyName("anyconnectDeviceId")]
	public string AnyconnectDeviceId { get; set; } = string.Empty;

	[JsonPropertyName("swgStatus")]
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public SwgStatus SwgStatus { get; set; }

	[JsonPropertyName("lastSyncSwgStatus")]
	public string LastSyncSwgStatus { get; set; } = string.Empty;
}
