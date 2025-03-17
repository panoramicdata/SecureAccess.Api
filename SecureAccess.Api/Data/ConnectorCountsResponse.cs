namespace SecureAccess.Api.Data;

/// <summary>
/// Represents the counts of the state information for the Connectors in the organization.
/// </summary>
public class ConnectorCountsResponse
{
	/// <summary>
	/// The number of Connectors in the organization that are in the announced state.
	/// </summary>
	public int Announced { get; set; }

	/// <summary>
	/// The number of Connectors in the organization that are in the connected state.
	/// </summary>
	public int Connected { get; set; }

	/// <summary>
	/// The number of Connectors in the organization that are in the disabled state.
	/// </summary>
	public int Disabled { get; set; }

	/// <summary>
	/// The number of the Connectors in the organization that are in the disconnected state.
	/// </summary>
	public int Disconnected { get; set; }

	/// <summary>
	/// The number of Connectors in the organization that are in the expired state.
	/// </summary>
	public int Expired { get; set; }

	/// <summary>
	/// The number of Connectors in the organization that require an update.
	/// </summary>
	public int NeedUpdateConnectorsCount { get; set; }

	/// <summary>
	/// The number of Connectors in the organization that are in the reachable state.
	/// </summary>
	public int Reachable { get; set; }

	/// <summary>
	/// The total number of Connectors in the organization.
	/// </summary>
	public int Total { get; set; }

	/// <summary>
	/// The number of Connectors in the organization that are unabled to sync.
	/// </summary>
	public int UnabledToSyncConnectorsCount { get; set; }

	/// <summary>
	/// The number of Connectors in the organization that are in the upgrading state.
	/// </summary>
	public int Upgrading { get; set; }
}
