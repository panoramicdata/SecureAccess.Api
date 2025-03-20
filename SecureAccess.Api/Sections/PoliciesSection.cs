using SecureAccess.Api.Interfaces;

namespace SecureAccess.Api.Sections;

public partial class PoliciesSection
{
	public IDestinationLists DestinationLists { get; set; } = null!;
}
