using System.Runtime.Serialization;

namespace SecureAccess.Api.Data;

public enum DestinationListAccess
{
	Unkown = 0,
	[EnumMember(Value = "allow")]
	Allow,
	[EnumMember(Value = "block")]
	Block,
	[EnumMember(Value = "url_proxy")]
	UrlProxy,
	[EnumMember(Value = "no_decrypt")]
	NoDecrypt,
	[EnumMember(Value = "warn")]
	Warn,
	[EnumMember(Value = "none")]
	None
}