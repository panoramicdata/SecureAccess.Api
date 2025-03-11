﻿namespace SecureAccess.Api.Data;

public class ConnectorGroupList
{
	public List<ConnectorGroupResponse> Data { get; set; } = [];
	public int Offset { get; set; }
	public int Limit { get; set; }
	public int Total { get; set; }
}
