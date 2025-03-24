using SecureAccess.Api.Data;

namespace SecureAccess.Api;

public partial class SecureAccessClient
{
	/// <summary>
	/// Get all entries from a paged API endpoint which uses "offset" query param for paging (mostly Deployments endpoints).
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="getPagedResultsAsync"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	internal static async Task<List<T>> GetAllAsync<T>(
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

	/// <summary>
	/// Get all entries from a paged API endpoint which uses "page" query param for paging (mostly Policies endpoints).
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	internal static async Task<List<T>> GetAllAsync<T>(
		Func<int, int, CancellationToken, Task<PagedResponseWithMeta<T>>> getPagedResultsAsync,
		CancellationToken cancellationToken = default)
	{
		var allEntries = new List<T>();
		var finished = false;
		var page = 1;
		var limit = 100;
		while (!finished)
		{
			var response = await getPagedResultsAsync(page, limit, cancellationToken).ConfigureAwait(false);
			allEntries.AddRange(response.Data);
			page++;
			if (response.Data.Count < limit)
			{
				finished = true;
			}
		}

		return allEntries;
	}
}
