namespace SecureAccess.Api.Data;

public class DestinationListCreateRequest : DestinationListUpdateRequest
{
	/// <summary>
	/// The access type. Valid values are: allow, block, url_proxy, no_decrypt, warn, or none.
	/// </summary>
	public DestinationListAccess Access { get; set; }

	/// <summary>
	/// Indicates whether the destination list is global. Must be false for non-global lists.
	/// </summary>
	public bool IsGlobal { get; set; }
}
