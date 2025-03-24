using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

public class DestinationList
{
	/// <summary>
	/// The destination list ID.
	/// </summary>
	[ApiKey]
	[ApiAccess(ApiAccess.Read)]
	public long Id { get; set; }

	/// <summary>
	/// The organization ID.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long OrganizationId { get; set; }

	/// <summary>
	/// The access type. Valid values are allow, block, url_proxy, no_decrypt, warn, or none.
	/// </summary>
	[ApiAccess(ApiAccess.ReadCreate)]
	public DestinationListAccess Access { get; set; }

	/// <summary>
	/// Specifies whether the destination list is a global destination list. There is only one default allow destination list and one default block destination list for an organization.
	/// Note: No support for global destination lists.When you create a destination list, set the isGlobal field to false.
	/// </summary>
	[ApiAccess(ApiAccess.ReadCreate)]
	public bool IsGlobal { get; set; }

	/// <summary>
	/// The name of the destination list.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Third party category ID.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long? ThirdpartyCategoryId { get; set; }
	/// <summary>
	/// The date and time when the destination list was created (as Unix epoch).
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long CreatedAt { get; set; }

	/// <summary>
	/// The date and time when the destination list was modified (as Unix epoch).
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long ModifiedAt { get; set; }

	/// <summary>
	/// Indicates if the destination list is the MSP default.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public bool IsMspDefault { get; set; }

	/// <summary>
	/// Specifies whether the destination list is marked for deletion.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public bool MarkedForDeletion { get; set; }

	/// <summary>
	/// The type of the destination list. In your policy rules, security controls are applied to your destination lists.
	/// Note: When you create a destination list, set the bundleTypeId to 2.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public int BundleTypeId { get; set; }

	/// <summary>
	/// The total number of each type of destination in the destination list. The fields in the meta object are optional.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DestinationListMeta? Meta { get; set; }
}
