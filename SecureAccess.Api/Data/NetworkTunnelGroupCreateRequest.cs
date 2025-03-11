using System.ComponentModel.DataAnnotations;

namespace SecureAccess.Api.Data;

public class NetworkTunnelGroupCreateRequest
{
	/// <summary>
	/// An IP address or ID for the network tunnel. The value of authIdPrefix is used to generate the ID portion of
	///the Pre-Shared Key(PSK).
	/// If you provide an IP, then you should include two IP addresses.
	///If you provide a string, ensure that the string is a sequence of 8–100 characters.
	///The string should not have any special characters besides the period(.), underscore(_), and dash(-) characters.
	/// </summary>
	public string AuthIdPrefix { get; set; } = string.Empty;

	/// <summary>
	/// The name of the Network Tunnel Group.
	/// A Network Tunnel Group name is a sequence of 1–50 characters.The name field cannot have any special characters other than spaces and hyphens.
	/// </summary>
	[MaxLength(50)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The name of the region that is used to get the primary and secondary data centers for the Hubs.
	/// </summary>
	public string Region { get; set; } = string.Empty;

	/// <summary>
	/// The type of device that establishes the network tunnel. The default value is other.
	/// enum = ["ASA", "FTD", "ISR", "Meraki MX", "Viptela cEdge", ...]
	/// </summary>
	public string? DeviceType { get; set; }

	/// <summary>
	/// The passphrase for the primary and secondary tunnels.
	///Provide a sequence of characters where the length of the passphrase is 16–64 characters.
	///The passphrase must contain at least one upper and one lowercase letter as well as one numeral.
	///The passphrase may not include special characters.
	/// </summary>
	public string Passphrase { get; set; } = string.Empty;

	/// <summary>
	/// The routing information for the network tunnel.
	/// The nat routing type is used when the tunnels in your organization connect to network spaces with overlapping IP address spaces.
	/// If the routing type is nat, then set the data field to null or an empty string.
	///If the routing type is bgp, then set the data field with the asNumber field.
	///If the routing type is static, then set the data field with the networkCIDRs field.
	/// </summary>
	public NetworkTunnelRouting? Routing { get; set; }
}
