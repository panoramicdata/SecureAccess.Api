using Refit;
using SecureAccess.Api.Data;
using SecureAccess.Api.Interfaces;

namespace SecureAccess.Api.Extensions;

public static class IDestinationListsExtensions
{
	/// <summary>
	/// Get the destination lists in your organization.
	/// </summary>
	/// <param name="destinationLists"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>A list of all DestinationLists</returns>
	[Get("/policies/v2/destinationlists")]
	public static Task<List<DestinationList>> GetDestinationListsAllAsync(
		this IDestinationLists destinationLists,
		CancellationToken cancellationToken = default)
		=> SecureAccessClient.GetAllAsync(
			(page, limit, cancellationToken) => destinationLists.GetDestinationListsAsync(page, limit, cancellationToken),
			cancellationToken);
}
