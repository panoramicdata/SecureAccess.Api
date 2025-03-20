namespace SecureAccess.Api.Data;

public class CreateOrUpdateResult<T>
{
	public T Data { get; set; } = default!;

	/// <summary>
	/// The status information for the response
	/// </summary>
	public ResponseStatus Status { get; set; } = new();
}
