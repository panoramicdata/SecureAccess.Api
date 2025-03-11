namespace SecureAccess.Api.Data;

public class NetworkTunnelRouting
{
	/// <summary>
	/// The type of the route
	/// </summary>
	public NetworkTunnelRoutingType Type { get; set; }

	/// <summary>
	/// The list of network CIDR addresses or the autonomous system (AS) number
	/// </summary>
	public object? Data { get; set; }
}