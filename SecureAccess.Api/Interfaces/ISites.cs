using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

public interface ISites
{
	/// <summary>
	/// Create a Site in the organization.
	/// </summary>
	/// <param name="request">The request object containing the site details.</param>
	/// <returns>The created Site as a <see cref="Site"/>.</returns>
	[Post("/sites")]
	Task<Site> CreateSiteAsync([Body]
		SiteCreateUpdateRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// List the Sites in the organization.
	/// </summary>
	/// <param name="page">
	/// The number of a page in the collection.
	/// Defaults to 1 if not specified.
	/// </param>
	/// <param name="limit">
	/// The number of items in the collection to return on the page.
	/// Defaults to 100 if not specified.
	/// </param>
	/// <returns>A list of <see cref="Site"/>.</returns>
	[Get("/sites")]
	Task<List<Site>> ListSitesAsync(
		int? page = null,
		int? limit = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get a Site in the organization.
	/// </summary>
	/// <param name="siteId">The ID of the Site.</param>
	/// <returns>The Site as a <see cref="Site"/>.</returns>
	[Get("/sites/{siteId}")]
	Task<Site> GetSiteAsync(
		long siteId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Update a Site in the organization.
	/// </summary>
	/// <param name="siteId">The ID of the Site.</param>
	/// <param name="request">The request object containing updated site details.</param>
	/// <returns>The updated Site as a <see cref="Site"/>.</returns>
	[Put("/sites/{siteId}")]
	Task<Site> UpdateSiteAsync(
		long siteId,
		[Body] SiteCreateUpdateRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Delete a Site in the organization.
	/// </summary>
	/// <param name="siteId">The ID of the Site.</param>
	/// <returns>A task representing the asynchronous delete operation.</returns>
	[Delete("/sites/{siteId}")]
	Task DeleteSiteAsync(
		long siteId,
		CancellationToken cancellationToken = default);
}
