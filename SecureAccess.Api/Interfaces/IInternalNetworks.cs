using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

/// <summary>
/// Interface for managing the internal networks in your organization.
/// </summary>
public interface IInternalNetworks
{
	/// <summary>
	/// Create an internal network.
	/// </summary>
	/// <param name="request">A JSON object that defines the internal network. Specify one of: siteId, networkId, or tunnelId.</param>
	/// <returns>The created internal network as an <see cref="InternalNetwork"/>.</returns>
	[Post("/internalnetworks")]
	Task<InternalNetwork> CreateInternalNetworkAsync(
		[Body] InternalNetworkCreateUpdateRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// List the internal networks.
	/// </summary>
	/// <param name="page">
	/// The number of a page in the collection.
	/// Defaults to 1 if not specified.
	/// </param>
	/// <param name="limit">
	/// The number of records to return on the page.
	/// Defaults to 100 if not specified.
	/// </param>
	/// <param name="name">
	/// Optional internal network label for filtering.
	/// </param>
	/// <returns>A list of <see cref="InternalNetwork"/>.</returns>
	[Get("/internalnetworks")]
	Task<List<InternalNetwork>> ListInternalNetworksAsync(
		int? page = null,
		int? limit = null,
		string? name = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get an internal network.
	/// </summary>
	/// <param name="internalNetworkId">
	/// The origin ID (originId) of the internal network.
	/// </param>
	/// <returns>The internal network as an <see cref="InternalNetwork"/>.</returns>
	[Get("/internalnetworks/{internalNetworkId}")]
	Task<InternalNetwork> GetInternalNetworkAsync(
		long internalNetworkId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Update an internal network.
	/// </summary>
	/// <param name="internalNetworkId">
	/// The origin ID (originId) of the internal network.
	/// </param>
	/// <param name="request">
	/// A JSON object that defines the internal network with updated properties.
	/// Specify one of: siteId, networkId, or tunnelId.
	/// </param>
	/// <returns>The updated internal network as an <see cref="InternalNetwork"/>.</returns>
	[Put("/internalnetworks/{internalNetworkId}")]
	Task<InternalNetwork> UpdateInternalNetworkAsync(
		long internalNetworkId,
		[Body] InternalNetworkCreateUpdateRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Delete an internal network.
	/// </summary>
	/// <param name="internalNetworkId">
	/// The origin ID (originId) of the internal network.
	/// </param>
	/// <returns>A task representing the asynchronous delete operation.</returns>
	[Delete("/internalnetworks/{internalNetworkId}")]
	Task DeleteInternalNetworkAsync(
		long internalNetworkId,
		CancellationToken cancellationToken = default);
}
