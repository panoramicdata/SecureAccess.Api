namespace SecureAccess.Api.Data;

public class ForwardDNS
{
	/// <summary>
	/// The ID for the DNS server that is associated with the Connector Group.
	/// </summary>
	public long DnsResourceId { get; set; }

	/// <summary>
	/// A comma-separated list of domains. DNS requests for these domains are sent to the DNS server that is identified by dnsResourceId
	/// </summary>
	public string Domains { get; set; } = string.Empty;
}