using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

public class NetworkTunnelGroupResponse : NetworkTunnelGroup
{

	/// <summary>
	/// The list of Hubs for a Network Tunnel Group.
	/// Only one Hub is the primary data center.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public new List<HubWithIp> Hubs { get; set; } = [];
}
