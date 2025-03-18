using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

public class InternalDomain
{
	/// <summary>
	/// The ID of the internal domain.
	/// </summary>
	[ApiKey]
	[ApiAccess(ApiAccess.Read)]
	public long Id { get; set; }

	/// <summary>
	/// The domain name of the internal domain.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Domain { get; set; } = string.Empty;

	/// <summary>
	/// The description of the internal domain.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Description { get; set; } = string.Empty;

	/// <summary>
	/// Specifies whether to apply the internal domain to all virtual appliances.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public bool IncludeAllVAs { get; set; }

	/// <summary>
	/// Specifies whether to apply the internal domain to all mobile devices.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public bool IncludeAllMobileDevices { get; set; }

	/// <summary>
	/// The date and time (ISO 8601 timestamp) when the internal domain was created.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The date and time (ISO 8601 timestamp) when the internal domain was modified.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime ModifiedAt { get; set; }

	/// <summary>
	/// The list of site IDs associated with the domain.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public List<long> SiteIds { get; set; } = [];
}
