namespace SecureAccess.Api.Data;

/// <summary>
/// Request model for removing SWG override device settings.
/// Provide a list of origin IDs for the devices in the organization.
/// The list can contain 1–100 origin IDs.
/// </summary>
public class SWGDeviceSettingsRemoveRequest
{
	/// <summary>
	/// The list of origin IDs. The list can contain 1–100 origin IDs.
	/// </summary>
	public List<long> OriginIds { get; set; } = [];
}
