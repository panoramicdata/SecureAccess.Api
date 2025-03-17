namespace SecureAccess.Api.Data;

/// <summary>
/// The OrgInfo.json properties for deploying the Cisco Secure Client on user devices in the organization.
/// The Cisco Secure Client with the Internet Security module requires the OrgInfo.json properties.
/// </summary>
public class OrgInfo
{
	/// <summary>
	/// The organization ID.
	/// </summary>
	public long OrganizationId { get; set; }

	/// <summary>
	/// The first 32 bits of the API key ID.
	/// </summary>
	public long UserId { get; set; }

	/// <summary>
	/// A hash that is used to register the Cisco Secure Client on users devices in the organization.
	/// </summary>
	public string Fingerprint { get; set; } = string.Empty;
}
