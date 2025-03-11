namespace SecureAccess.Api.Data;

public class NetworkTunnelGroupPatchOperation
{
	public PatchOperationType Op { get; set; }

	public NetworkTunnelGroupPatchOperationPath Path { get; set; }

	public object Value { get; set; } = null!;
}
