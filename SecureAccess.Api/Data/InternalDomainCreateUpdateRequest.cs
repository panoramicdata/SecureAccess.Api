namespace SecureAccess.Api.Data;

public class InternalDomainCreateUpdateRequest
{
	/// <summary>
	/// The internal domain.
	/// </summary>
	public string Domain { get; set; } = string.Empty;

	/// <summary>
	/// The description of the internal domain.
	/// The description is a sequence of characters with a length from 1 through 50.
	/// </summary>
	public string Description { get; set; } = string.Empty;

	/// <summary>
	/// Specifies whether to apply the internal domain to all virtual appliances.
	/// </summary>
	public bool IncludeAllVAs { get; set; }

	/// <summary>
	/// Specifies whether to apply the internal domain to all mobile devices.
	/// </summary>
	public bool IncludeAllMobileDevices { get; set; }

	/// <summary>
	/// The list of site IDs associated with the domain.
	/// </summary>
	public List<long> SiteIds { get; set; } = [];
}
