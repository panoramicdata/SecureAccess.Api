namespace SecureAccess.Api.Data;

public class PagedResponse<T>
{
	public List<T> Data { get; set; } = [];

	public int Offset { get; set; }

	public int Limit { get; set; }

	public int Total { get; set; }
}
