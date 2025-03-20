namespace SecureAccess.Api.Data;

public class PaginatedResponse<T>
{
	/// <summary>
	/// The data returned in the response
	/// </summary>
	public List<T> Data { get; set; } = [];

	/// <summary>
	/// The pagination information for the response
	/// </summary>
	public PaginatedResponseMeta Meta { get; set; } = new();

	/// <summary>
	/// The status information for the response
	/// </summary>
	public ResponseStatus Status { get; set; } = new();
}
