using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

/// <summary>
/// Request model for updating a roaming computer's name.
/// </summary>
public class UpdateRoamingComputerRequest
{
	[JsonPropertyName("name")]
	[Required]
	[MaxLength(50)]
	public string Name { get; set; } = string.Empty;
}
