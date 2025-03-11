namespace SecureAccess.Api.Data;

public class DatacenterWithIp : Datacenter
{
	/// <summary>
	/// The IP address of the data center for the Hub.
	/// </summary>
	public string Ip { get; set; } = string.Empty;
}