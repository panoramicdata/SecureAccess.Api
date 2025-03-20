namespace SecureAccess.Api.Data;

/// <summary>
/// The meta object contains the total number of each type of destination in the destination list.
/// The fields in the meta object are optional.
/// </summary>
public class DestinationListMeta
{
	/// <summary>
	/// The total number of applications in a destination list.
	/// Applications are part of the total number of destinations in a destination list.
	/// </summary>
	public long ApplicationCount { get; set; }

	/// <summary>
	/// The total number of destinations in a destination list.
	/// </summary>
	public long DestinationCount { get; set; }

	/// <summary>
	/// The total number of domains in a destination list.
	/// Domains are part of the total number of destinations in a destination list.
	/// </summary>
	public long DomainCount { get; set; }

	/// <summary>
	/// The total number of IPv4 addresses in a destination list.
	/// IPv4 addresses are part of the total number of destinations in a destination list.
	/// </summary>
	public long Ipv4Count { get; set; }

	/// <summary>
	/// The total number of IPv6 addresses in a destination list.
	/// IPv6 addresses are part of the total number of destinations in a destination list.
	/// </summary>
	public long Ipv6Count { get; set; }

	/// <summary>
	/// The total number of URLs in a destination list.
	/// URLs are part of the total number of destinations in a destination list.
	/// </summary>
	public long UrlCount { get; set; }

}