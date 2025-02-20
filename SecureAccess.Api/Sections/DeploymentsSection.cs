using SecureAccess.Api.Interfaces;

namespace SecureAccess.Api.Sections;
public partial class DeploymentsSection
{
	public IRoamingComputers RoamingComputers { get; set; } = null!;
}
