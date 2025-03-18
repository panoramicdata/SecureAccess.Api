using SecureAccess.Api.Interfaces;

namespace SecureAccess.Api.Sections;
public partial class DeploymentsSection
{
	public INetworkTunnelGroups NetworkTunnelGroups { get; set; } = null!;

	public IConnectorGroups ConnectorGroups { get; set; } = null!;

	public IRoamingComputers RoamingComputers { get; set; } = null!;

	public ISwgDeviceSettings SwgDeviceSettings { get; set; } = null!;

	public IInternalDomains InternalDomains { get; set; } = null!;

	public ISites Sites { get; set; } = null!;

	public IInternalNetworks InternalNetworks { get; set; } = null!;
}
