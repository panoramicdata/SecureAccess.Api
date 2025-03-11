using SecureAccess.Api.Attributes;

namespace SecureAccess.Api.Data;

public class Hub
{
	/// <summary>
	/// The ID of the Hub.
	/// </summary>
	[ApiKey]
	public int Id { get; set; }

	/// <summary>
	/// Specifies whether the Hub is a primary data center.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public bool IsPrimary { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public Datacenter Datacenter { get; set; } = null!;

	/// <summary>
	/// An IP address or email used to authenticate the tunnel.
	/// </summary>
	[ApiAccess(ApiAccess.Read)]
	public string AuthId { get; set; } = string.Empty;
}