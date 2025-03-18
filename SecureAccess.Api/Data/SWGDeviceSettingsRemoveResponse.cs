namespace SecureAccess.Api.Data;

/// <summary>
/// Response model for removing SWG override device settings.
/// Contains a status message indicating the outcome.
/// </summary>
public class SWGDeviceSettingsRemoveResponse
{
	/// <summary>
	/// Deleted SWG override setting on the devices.
	/// Example: "No content"
	/// </summary>
	public string Status { get; set; } = string.Empty;
}
