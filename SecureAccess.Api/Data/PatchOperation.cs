namespace SecureAccess.Api.Data;

public class PatchOperation
{
	public PatchOperationType Op { get; set; } = PatchOperationType.Replace;

	public string Path { get; set; } = string.Empty;

	public object Value { get; set; } = string.Empty;
}
