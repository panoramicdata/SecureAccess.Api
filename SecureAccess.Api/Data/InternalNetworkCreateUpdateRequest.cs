namespace SecureAccess.Api.Data;

/// <summary>
/// Request model for creating or updating an internal network.
/// Specify one of: <c>siteId</c>, <c>networkId</c>, or <c>tunnelId</c>.
/// </summary>
public class InternalNetworkCreateUpdateRequest
{
	/// <summary>
	/// The name of the internal network.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The IP (IPv4 or IPv6) address of the internal network.
	/// </summary>
	public string IpAddress { get; set; } = string.Empty;

	/// <summary>
	/// The length of the internal network's prefix. The prefix length is between 8 and 32.
	/// </summary>
	public int PrefixLength { get; set; }

	/// <summary>
	/// The ID of the site associated with the internal network.
	/// Specify one of: <c>siteId</c>, <c>networkId</c>, or <c>tunnelId</c>.
	/// </summary>
	public int? SiteId { get; set; }

	/// <summary>
	/// The ID of the network associated with the internal network.
	/// Specify one of: <c>siteId</c>, <c>networkId</c>, or <c>tunnelId</c>.
	/// </summary>
	public int? NetworkId { get; set; }

	/// <summary>
	/// The ID of the network tunnel group associated with the internal network.
	/// Specify one of: <c>siteId</c>, <c>networkId</c>, or <c>tunnelId</c>.
	/// </summary>
	public int? TunnelId { get; set; }
}
