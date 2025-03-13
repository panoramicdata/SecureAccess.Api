namespace SecureAccess.Api.Data;

public class ConnectorGroupCreateUpdateRequest
{
	/// <summary>
	/// The name of the Resource Connector Group. The name may include alphanumeric characters, and the space(' ') and hyphen(-) characters
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// The region where the Resource Connector Group is available
	/// </summary>
	public string Location { get; set; } = string.Empty;

	/// <summary>
	/// The type of cloud-native runtime environment that hosts the Resource Connector Group. default = "aws", enum = ["aws", "azure", "container", "esx"]
	/// </summary>
	public ConnectorGroupEnvironment Environment { get; set; } = ConnectorGroupEnvironment.Aws;

	/// <summary>
	/// The DNS configuration for the Connector Group
	/// </summary>
	public List<ForwardDNS>? ForwardDNS { get; set; }
}
