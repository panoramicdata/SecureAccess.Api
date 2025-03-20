using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

/// <summary>
/// The Secure Access Destination Lists API enables you to create and manage access to network destinations. 
/// You can block or allow a destination on your policy access rules in Secure Access.
/// </summary>
public interface IDestinationLists
{
	/// <summary>
	/// Get the destination lists in your organization.
	/// </summary>
	/// <param name="page">The page number (default is 1).</param>
	/// <param name="limit">The number of records per page (default is 100).</param>
	/// <returns>A paginated response containing destination lists.</returns>
	[Get("/policies/v2/destinationlists")]
	Task<PaginatedResponse<DestinationList>> GetDestinationListsAsync(
		int? page = null,
		int? limit = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Create a destination list in your organization.
	/// </summary>
	/// <param name="request">The destination list creation request.</param>
	/// <returns>The created destination list wrapped in a response object.</returns>
	[Post("/policies/v2/destinationlists")]
	Task<CreateOrUpdateResult<DestinationList>> CreateDestinationListAsync(
		[Body] DestinationListCreateRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Update a destination list in your organization.
	/// </summary>
	/// <param name="destinationListId">The ID of the destination list.</param>
	/// <param name="request">The destination list patch request.</param>
	/// <returns>The updated destination list response.</returns>
	[Patch("/policies/v2/destinationlists/{destinationListId}")]
	Task<CreateOrUpdateResult<DestinationList>> UpdateDestinationListAsync(
		long destinationListId,
		[Body] DestinationListUpdateRequest request);

	/// <summary>
	/// Delete a destination list from your organization.
	/// </summary>
	/// <param name="destinationListId">The ID of the destination list.</param>
	/// <returns>A response indicating the deletion result.</returns>
	[Delete("/policies/v2/destinationlists/{destinationListId}")]
	Task<CreateOrUpdateResult<DestinationList>> DeleteDestinationListAsync(
		[AliasAs("destinationListId")] long destinationListId);

	/// <summary>
	/// Get a destination list.
	/// </summary>
	/// <param name="destinationListId">The ID of the destination list.</param>
	/// <returns>The destination list response.</returns>
	[Get("/policies/v2/destinationlists/{destinationListId}")]
	Task<CreateOrUpdateResult<DestinationList>> GetDestinationListAsync(
		[AliasAs("destinationListId")] int destinationListId);
}
