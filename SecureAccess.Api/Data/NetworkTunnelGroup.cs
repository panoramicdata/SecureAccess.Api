using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

public class NetworkTunnelGroup
{
	/// <summary>
	/// The ID of the Network Tunnel Group.
	/// </summary>
	[ApiKey]
	public int Id { get; set; }

	/// <summary>
	/// The name of the Network Tunnel Group.
	/// A Network Tunnel Group name is a sequence of 1–50 characters.The name field cannot have any special characters other than spaces and hyphens.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The ID of the Network Tunnel Group
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public int OrganizationId { get; set; }

	/// <summary>
	/// The type of device that establishes the network tunnel. The default value is other.
	/// enum = ["ASA", "FTD", "ISR", "Meraki MX", "Viptela cEdge", ...]
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string DeviceType { get; set; } = string.Empty;

	/// <summary>
	/// The name of the region that is used to get the primary and secondary data centers for the Hubs.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Region { get; set; } = string.Empty;

	/// <summary>
	/// The status of the Network Tunnel Group.
	/// enum = ["connected", "disconnected", "warning"]
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public string Status { get; set; } = string.Empty;

	/// <summary>
	/// The list of Hubs for a Network Tunnel Group.
	/// Only one Hub is the primary data center.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public List<Hub> Hubs { get; set; } = [];

	/// <summary>
	/// The routing information for the network tunnel.
	/// If the routing type is nat, then the data field is empty.
	/// If the routing type is bgp, then data includes the asNumber field.
	/// If the routing type is static, then data includes the networkCIDRs field.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public NetworkTunnelRouting Routing { get; set; } = null!;

	/// <summary>
	/// The date and time (timestamp) when the network tunnel group was created.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The date and time of the last update (timestamp) for the network tunnel group.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime ModifiedAt { get; set; }
}
