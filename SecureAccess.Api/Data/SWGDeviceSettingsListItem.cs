using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

/// <summary>
/// Model representing a single Secure Web Gateway (SWG) device setting as returned by the list endpoint.
/// </summary>
public class SWGDeviceSettingsListItem
{
	/// <summary>
	/// The origin ID of the device.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public long OriginId { get; set; }

	/// <summary>
	/// The name of the device setting.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The SWG device setting value.
	/// Valid values are: "0" or "1".
	/// </summary>
	[ApiAccess(ApiAccess.ReadCreate)]
	public string Value { get; set; } = string.Empty;

	/// <summary>
	/// The date and time when the settings on the device were modified.
	/// The timestamp is in the ISO 8601 date format.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public DateTime ModifiedAt { get; set; }
}