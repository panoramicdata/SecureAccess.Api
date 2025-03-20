namespace SecureAccess.Api.Data;

/// <summary>
/// The pagination information for the response
/// </summary>
public class PaginatedResponseMeta
{
	/// <summary>
	/// The maximum number of items that are returned on the page.
	/// </summary>
	public int Limit { get; set; }

	/// <summary>
	/// The number of the page in the collection
	/// </summary>
	public int Page { get; set; }

	/// <summary>
	/// The total number of items in the collection
	/// </summary>
	public int Total { get; set; }
}