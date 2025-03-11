using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

public class NetworkTunnelGroupsList
{
	[ApiAccess(ApiAccess.Read)]
	public List<NetworkTunnelGroup> Data { get; set; } = [];

	[ApiAccess(ApiAccess.Read)]
	public int Offset { get; set; }

	[ApiAccess(ApiAccess.Read)]
	public int Limit { get; set; }

	[ApiAccess(ApiAccess.Read)]
	public int Total { get; set; }
}
