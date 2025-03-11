using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public enum PatchOperationType
{
	[JsonPropertyName("replace")]
	Replace
}