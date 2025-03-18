namespace SecureAccess.Api.Data;

public class SWGDeviceSettingStatus
{
	/// <summary>
	/// The origin ID of the device.
	/// </summary>
	public long OriginId { get; set; }

	/// <summary>
	/// The status code of the response.
	/// </summary>
	public int Code { get; set; }

	/// <summary>
	/// The description of the response.
	/// </summary>
	public string Message { get; set; } = string.Empty;
}