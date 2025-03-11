using SecureAccess.Api.Interfaces;

namespace SecureAccess.Api.Sections;
public partial class DeploymentsSection
{
	public INetworkTunnelGroups NetworkTunnelGroups { get; set; } = null!;

	public IRoamingComputers RoamingComputers { get; set; } = null!;
}
