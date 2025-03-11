namespace SecureAccess.Api.Data;

class ApiError
{
	/// <summary>
	/// Error message explaining the reason for failure
	/// </summary>
	public string Error { get; set; } = string.Empty;

	/// <summary>
	/// The ID of the request
	/// </summary>
	public string RequestId { get; set; } = string.Empty;
}
