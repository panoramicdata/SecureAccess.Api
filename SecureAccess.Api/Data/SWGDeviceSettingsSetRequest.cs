namespace SecureAccess.Api.Data;

/// <summary>
/// Request model for setting SWG override device settings.
/// Provide a list of origin IDs for the devices in the organization and the SWG device setting value.
/// The list can contain 1–100 origin IDs.
/// </summary>
public class SWGDeviceSettingsSetRequest
{
	/// <summary>
	/// The list of origin IDs. The list can contain 1–100 origin IDs.
	/// </summary>
	public List<long> OriginIds { get; set; } = [];

	/// <summary>
	/// Specifies whether to enable the Secure Web Gateway (SWG) device settings.
	/// Valid values are: "0" or "1" where "1" indicates enable.
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
