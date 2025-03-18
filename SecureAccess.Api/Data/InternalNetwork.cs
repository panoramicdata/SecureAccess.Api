using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

public class InternalNetwork
{
	/// <summary>
	/// The origin ID of the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long OriginId { get; set; }

	/// <summary>
	/// The name of the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The IP (IPv4 or IPv6) address of the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string IpAddress { get; set; } = string.Empty;

	/// <summary>
	/// The length of the internal network's prefix.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public int PrefixLength { get; set; }

	/// <summary>
	/// The name of the site that is associated with the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public string? SiteName { get; set; }

	/// <summary>
	/// The ID of the site associated with the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public long? SiteId { get; set; }

	/// <summary>
	/// The name of the network that is associated with the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public string? NetworkName { get; set; }

	/// <summary>
	/// The ID of the network associated with the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public long? NetworkId { get; set; }

	/// <summary>
	/// The name of the network tunnel group that is associated with the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public string? TunnelName { get; set; }

	/// <summary>
	/// The ID of the network tunnel group associated with the internal network.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public long? TunnelId { get; set; }

	/// <summary>
	/// The date and time (ISO8601 timestamp) when the internal network was created.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The date and time (ISO8601 timestamp) when the internal network was modified.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime ModifiedAt { get; set; }
}
