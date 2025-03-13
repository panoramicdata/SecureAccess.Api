namespace SecureAccess.Api.Data;

public enum ConnectorGroupStatus
{
	Unknown = 0,
	Waiting,
	Connected,
	Overloaded,
	Disabled,
	Disconnected
}