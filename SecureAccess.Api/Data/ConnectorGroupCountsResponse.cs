namespace SecureAccess.Api.Data;

/// <summary>
/// Represents the counts of the state information for the Resource Connector Groups in the organization.
/// </summary>
public class ConnectorGroupCountsResponse
{
	/// <summary>
	/// The number of Resource Connector Groups in the organization that are in the connected state.
	/// </summary>
	public int Connected { get; set; }

	/// <summary>
	/// The number of Resource Connector Groups in the organization that are in the disabled state.
	/// </summary>
	public int Disabled { get; set; }

	/// <summary>
	/// The number of the Resource Connector Groups in the organization that are in the disconnected state.
	/// </summary>
	public int Disconnected { get; set; }

	/// <summary>
	/// The number of Resource Connector Groups in the organization that have at least one disconnected Connector.
	/// </summary>
	public int HasDisconnectedConnector { get; set; }

	/// <summary>
	/// The number of Resource Connector Groups in the organization without any assigned private resources.
	/// </summary>
	public int NoAssignedResources { get; set; }

	/// <summary>
	/// The total number of Resource Connector Groups in the organization.
	/// </summary>
	public int Total { get; set; }

	/// <summary>
	/// The number of Resource Connector Groups in the organization that are in the waiting state.
	/// </summary>
	public int Waiting { get; set; }
}
