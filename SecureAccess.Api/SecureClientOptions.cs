namespace SecureAccess.Api;

/// <summary>
/// Secure Access Client Options
/// </summary>
public class SecureClientOptions
{
	/// <summary>
	/// The API URL
	/// </summary>
	public string ApiUrl { get; set; } = string.Empty;

	/// <summary>
	/// The API Key
	/// </summary>
	public string ApiKey { get; set; } = string.Empty;

	/// <summary>
	/// The API Secret
	/// </summary>
	public string ApiSecret { get; set; } = string.Empty;

	/// <summary>
	/// The Key Admin API Key
	/// </summary>
	public string? KeyAdminApiKey { get; set; }

	/// <summary>
	/// The Key Admin API Secret
	/// </summary>
	public string? KeyAdminApiSecret { get; set; }
}