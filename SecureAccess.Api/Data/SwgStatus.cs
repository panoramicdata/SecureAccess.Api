using System.Runtime.Serialization;

namespace SecureAccess.Api.Data;

public enum SwgStatus
{
	Unknown = 0,

	[EnumMember(Value = "Off")]
	Off,

	[EnumMember(Value = "NA")]
	NA,

	[EnumMember(Value = "Protected")]
	Protected,

	[EnumMember(Value = "Unprotected")]
	Unprotected,

	[EnumMember(Value = "Disabled")]
	Disabled
}
