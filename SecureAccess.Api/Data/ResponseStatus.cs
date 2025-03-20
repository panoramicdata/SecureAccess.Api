namespace SecureAccess.Api.Data;

public class ResponseStatus
{
	/// <summary>
	/// The HTTP status code of the response.
	/// </summary>
	public int Code { get; set; }
	/// <summary>
	/// The HTTP message that describes the response.
	/// </summary>
	public string Text { get; set; } = string.Empty;
}