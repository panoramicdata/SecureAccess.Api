using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

public interface ISwgDeviceSettings
{
	/// <summary>
	/// Add a list of origin IDs and the Secure Web Gateway (SWG) setting for devices in the organization.
	/// The SWG device setting overrides the organization-level SWG setting.
	/// Note: The device must first be registered as a roaming computer with Secure Access.
	/// </summary>
	/// <param name="request">The request containing the SWG setting value and a list of origin IDs.</param>
	/// <returns>A <see cref="RegisteredSWGDeviceSettings"/> response detailing the outcome per device.</returns>
	[Post("/deployments/v2/deviceSettings/SWGEnabled/set")]
	Task<RegisteredSWGDeviceSettings> CreateSecureWebGatewayDeviceSettingsAsync(
		[Body] SWGDeviceSettingsSetRequest request);

	/// <summary>
	/// List the Secure Web Gateway (SWG) override settings for devices in the organization.
	/// </summary>
	/// <param name="originIds">The list of origin IDs. The list can contain 1–100 origin IDs.</param>
	/// <returns>The list of Secure Web Gateway (SWG) settings for the devices in the organization.</returns>
	[Post("/deployments/v2/deviceSettings/SWGEnabled/list")]
	Task<List<SWGDeviceSettingsListItem>> ListSecureWebGatewayDeviceSettingsAsync(
		[Body] List<string> originIds);

	/// <summary>
	/// Remove the Secure Web Gateway (SWG) override setting for the devices in the organization.
	/// Once removed, Secure Access applies your organization's SWG setting to the device.
	/// </summary>
	/// <param name="request">The request containing a list of origin IDs.</param>
	/// <returns>A <see cref="SWGDeviceSettingsRemoveResponse"/> containing a status message.</returns>
	[Post("/deployments/v2/deviceSettings/SWGEnabled/remove")]
	Task<SWGDeviceSettingsRemoveResponse> DeleteSecureWebGatewayDeviceSettingsAsync(
		[Body] SWGDeviceSettingsRemoveRequest request);
}
