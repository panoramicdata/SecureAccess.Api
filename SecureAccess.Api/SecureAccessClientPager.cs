using SecureAccess.Api.Data;

namespace SecureAccess.Api;

public partial class SecureAccessClient
{
	public static async Task<List<T>> GetAllAsync<T>(
		Func<int, int, CancellationToken, Task<PagedResponse<T>>> getPagedResultsAsync,
		CancellationToken cancellationToken = default)
	{
		var allEntries = new List<T>();

		var finished = false;
		var offset = 0;
		var limit = 100;

		while (!finished)
		{
			var page = await getPagedResultsAsync(offset, limit, cancellationToken).ConfigureAwait(false);
			allEntries.AddRange(page.Data);
			offset += limit;

			if (offset >= page.Total)
			{
				finished = true;
			}
		}

		return allEntries;
	}
}
