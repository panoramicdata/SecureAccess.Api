namespace SecureAccess.Api.Data;

public class SiteCreateUpdateRequest
{
	/// <summary>
	/// The name of the Site.
	/// The name is a sequence of 1–255 characters.
	/// </summary>
	public string Name { get; set; } = string.Empty;
}
