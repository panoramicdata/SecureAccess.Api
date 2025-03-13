using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

/// <summary>
/// Represents the Resource Connector Group response object.
/// </summary>
public class ConnectorGroup
{
	/// <summary>
	/// Gets or sets the number of Connectors in the Resource Connector Group that are synced and connected.
	/// </summary>
	public long ConnectedConnectorsCount { get; set; }

	/// <summary>
	/// Gets or sets the number of Connectors in the Resource Connector Group.
	/// </summary>
	public long ConnectorsCount { get; set; }

	/// <summary>
	/// Gets or sets the number of Connectors in the Resource Connector Group that are disconnected.
	/// </summary>
	public long DisconnectedConnectorsCount { get; set; }

	/// <summary>
	/// Gets the ID of the Resource Connector Group.
	/// </summary>
	public long Id { get; set; }

	/// <summary>
	/// Gets or sets the number of Connectors in the Resource Connector Group that require an update.
	/// </summary>
	public long NeedUpdateConnectorsCount { get; set; }

	/// <summary>
	/// Gets or sets the number of Connectors in the Resource Connector Group that are unabled to sync.
	/// </summary>
	public long UnabledToSyncConnectorsCount { get; set; }

	/// <summary>
	/// Gets the URL of the Connector Group's base image.
	/// </summary>
	public string? BaseImageDownloadUrl { get; set; }

	/// <summary>
	/// Gets the date and time when the Resource Connector Group was created, specified in the ISO 8601 format.
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the type of cloud-native runtime environment that hosts the Resource Connector Group.
	/// Default is "aws". Allowed values: "aws", "azure", "container", "esx".
	/// </summary>
	public ConnectorGroupEnvironment Environment { get; set; }

	/// <summary>
	/// Gets or sets the region where the Resource Connector Group is available.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Location { get; set; } = string.Empty;

	/// <summary>
	/// Gets the date and time when the Resource Connector Group was modified, specified in the ISO 8601 format.
	/// </summary>
	public DateTime ModifiedAt { get; set; }

	/// <summary>
	/// Gets or sets the name of the Resource Connector Group.
	/// The name may include alphanumeric characters, spaces, and hyphens.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the Resource Connector Group's provisioning key.
	/// </summary>
	public string? ProvisioningKey { get; set; }

	/// <summary>
	/// Gets the date and time when the Resource Connector Group's provisioning key expires, specified in the ISO 8601 format.
	/// </summary>
	public DateTime ProvisioningKeyExpiresAt { get; set; }

	/// <summary>
	/// Gets or sets the label that describes the status of the Resource Connector Group.
	/// Allowed values: "waiting", "connected", "overloaded", "disabled", "disconnected".
	/// </summary>
	public ConnectorGroupStatus Status { get; set; }

	/// <summary>
	/// Gets the date and time when the Resource Connector Group's status was updated, specified in the ISO 8601 format.
	/// </summary>
	public DateTime StatusUpdatedAt { get; set; }

	/// <summary>
	/// Gets or sets the list of resource IDs.
	/// </summary>
	public List<long>? ResourceIds { get; set; }

	/// <summary>
	/// Gets or sets the DNS configuration for the Connector Group.
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	public List<ForwardDNS>? ForwardDNS { get; set; }
}
