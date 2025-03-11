using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public enum NetworkTunnelGroupPatchOperationPath
{
	Unknown = 0,

	[JsonPropertyName("/name")]
	Name,

	[JsonPropertyName("/authIdPrefix")]
	AuthIdPrefix,

	[JsonPropertyName("/passphrase")]
	Passphrase,

	[JsonPropertyName("/region")]
	Region,

	[JsonPropertyName("/routing")]
	Routing
}