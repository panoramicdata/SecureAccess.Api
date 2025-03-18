namespace SecureAccess.Api.Data;

/// <summary>
/// Response model for setting SWG override device settings.
/// Contains overall counts and a list of device status items.
/// </summary>
public class RegisteredSWGDeviceSettings
{
	/// <summary>
	/// The total number of devices that requested to update the device setting.
	/// </summary>
	public int TotalCount { get; set; }

	/// <summary>
	/// The number of devices that successfully changed the device setting.
	/// </summary>
	public int SuccessCount { get; set; }

	/// <summary>
	/// The number of devices that failed to change the device setting.
	/// </summary>
	public int FailCount { get; set; }

	/// <summary>
	/// The list of device setting status properties.
	/// </summary>
	public List<SWGDeviceSettingStatus> Items { get; set; } = [];

	/// <summary>
	/// Specifies whether to enable the Secure Web Gateway (SWG) device settings.
	/// Valid values are: "0" or "1" where "1" indicates enable.
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
