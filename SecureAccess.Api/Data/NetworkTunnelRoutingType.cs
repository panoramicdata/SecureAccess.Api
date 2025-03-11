using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public enum NetworkTunnelRoutingType
{
	[JsonPropertyName("static")]
	Static,
	[JsonPropertyName("bgp")]
	Bgp,
	[JsonPropertyName("nat")]
	Nat
}