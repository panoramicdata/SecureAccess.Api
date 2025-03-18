using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

/// <summary>
/// Represents a Site in the organization.
/// </summary>
public class Site
{
	/// <summary>
	/// The origin ID of the Site.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long OriginId { get; set; }

	/// <summary>
	/// The name of the Site.
	/// The name is a sequence of 1–255 characters.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The ID of the Site.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long SiteId { get; set; }

	/// <summary>
	/// Specifies whether the Site is the default Site.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public bool IsDefault { get; set; }

	/// <summary>
	/// The type of the Site.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public string Type { get; set; } = string.Empty;

	/// <summary>
	/// The number of internal networks that are associated with the Site.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public int? InternalNetworkCount { get; set; }

	/// <summary>
	/// The number of virtual appliances that are associated with the Site.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public int? VaCount { get; set; }

	/// <summary>
	/// The date and time (ISO 8601 timestamp) when the Site was created.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The date and time (ISO 8601 timestamp) when the Site was modified.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime ModifiedAt { get; set; }
}
