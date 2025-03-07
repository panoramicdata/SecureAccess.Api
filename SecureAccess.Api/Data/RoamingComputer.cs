using SecureAccess.Api.Attributes;
using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;
public class RoamingComputer
{
	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("originId")]
	public long OriginId { get; set; }

	[ApiKey]
	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("deviceId")]
	public string DeviceId { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("type")]
	public string Type { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("status")]
	public string Status { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("lastSyncStatus")]
	public string LastSyncStatus { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("lastSync")]
	public DateTime LastSync { get; set; }

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("version")]
	public string Version { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.ReadUpdate)]
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("hasIpBlocking")]
	public bool HasIpBlocking { get; set; }

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("appliedBundle")]
	public int AppliedBundle { get; set; }

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("osVersion")]
	public string OsVersion { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("osVersionName")]
	public string OsVersionName { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("anyconnectDeviceId")]
	public string AnyconnectDeviceId { get; set; } = string.Empty;

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("swgStatus")]
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public SwgStatus SwgStatus { get; set; }

	[ApiAccess(ApiAccess.Read)]
	[JsonPropertyName("lastSyncSwgStatus")]
	public string LastSyncSwgStatus { get; set; } = string.Empty;
}
