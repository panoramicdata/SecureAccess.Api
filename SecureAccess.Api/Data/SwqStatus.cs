using System.Runtime.Serialization;

namespace SecureAccess.Api.Data;

public enum SwqStatus
{
	Unknown = 0,

	[EnumMember(Value = "connected")]
	Connected,

	[EnumMember(Value = "disconnected")]
	Disconnected,

	[EnumMember(Value = "warning")]
	Warning
}