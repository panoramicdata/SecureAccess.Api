using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

/// <summary>
/// Represents a Resource Connector.
/// </summary>
public class Connector
{
	/// <summary>
	/// The ID of the Connector.
	/// </summary>
	public long Id { get; set; }

	/// <summary>
	/// The ID of the Resource Connector Group.
	/// </summary>
	public long GroupId { get; set; }

	/// <summary>
	/// The globally unique ID of the Connector instance.
	/// </summary>
	public string? InstanceId { get; set; }

	/// <summary>
	/// Indicates whether the Connector exists.
	/// Default is false.
	/// </summary>
	[ApiAccess(ApiAccess.ReadUpdate)]
	public bool Confirmed { get; set; }

	/// <summary>
	/// Indicates whether the Connector can receive traffic.
	/// Default is false.
	/// </summary>
	[ApiAccess(ApiAccess.ReadUpdate)]
	public bool Enabled { get; set; }

	/// <summary>
	/// The runtime version of the Connector image.
	/// </summary>
	public string? Version { get; set; }

	/// <summary>
	/// The unique ID of the Connector formatted as a hash string.
	/// </summary>
	public string? Sha1 { get; set; }

	/// <summary>
	/// The unique hostname of the device that manages the runtime of the Connector.
	/// </summary>
	public string? Hostname { get; set; }

	/// <summary>
	/// The public IP address of the Connector.
	/// </summary>
	public string? OriginIpAddress { get; set; }

	/// <summary>
	/// The base OS version of the Connector image.
	/// Updating the base OS version requires that you download and redeploy the latest Connector image.
	/// </summary>
	public string? BaseVersion { get; set; }

	/// <summary>
	/// Indicates whether the Connector is using the latest available image.
	/// If false, a new image is available to download. We recommend that you redeploy this Connector with the latest image.
	/// (readOnly)
	/// </summary>
	public bool IsLatestBaseVersion { get; set; }

	/// <summary>
	/// The status of the latest over-the-air update for this Connector.
	/// Over-the-air updates modify the Connector agent software without requiring a new image and redeployment.
	/// Allowed values: "successful", "in_progress", "failed", "unknown".
	/// (readOnly)
	/// </summary>
	public ConnectorUpgradeStatus UpgradeStatus { get; set; }

	/// <summary>
	/// The label that describes the status of the Connector.
	/// Allowed values: "disconnected", "connected", "announced", "reachable", "disabled".
	/// Default is "announced".
	/// </summary>
	public ConnectorStatus Status { get; set; }

	/// <summary>
	/// The date and time when the Connector was updated, specified in ISO 8601 format.
	/// </summary>
	public DateTime StatusUpdatedAt { get; set; }

	/// <summary>
	/// The date and time when the Connector's controller status was last updated, specified in ISO 8601 format.
	/// </summary>
	public DateTime? ControlStatusUpdatedAt { get; set; }

	/// <summary>
	/// The date and time when the Connector was removed, specified in ISO 8601 format.
	/// </summary>
	public DateTime? Revoked_at { get; set; }

	/// <summary>
	/// The date and time when the Connector was created, specified in ISO 8601 format.
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The date and time when the Connector was last modified, specified in ISO 8601 format.
	/// </summary>
	public DateTime ModifiedAt { get; set; }
}
