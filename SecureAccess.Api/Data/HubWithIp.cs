namespace SecureAccess.Api.Data;

public class HubWithIp : Hub
{
	/// <summary>
	/// 
	/// </summary>
	public new DatacenterWithIp Datacenter { get; set; } = null!;
}