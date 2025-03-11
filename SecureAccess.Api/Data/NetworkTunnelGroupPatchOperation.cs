namespace SecureAccess.Api.Data;

public class NetworkTunnelGroupPatchOperation
{
	public PatchOperationType Op { get; set; } = PatchOperationType.Replace;

	public NetworkTunnelGroupPatchOperationPath Path { get; set; }

	public object Value { get; set; } = string.Empty;
}
