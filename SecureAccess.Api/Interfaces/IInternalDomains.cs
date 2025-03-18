using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

/// <summary>
/// Interface for managing the internal domains in your organization.
/// </summary>
public interface IInternalDomains
{
	/// <summary>
	/// Create an internal domain.
	/// If you do not assign a list of sites to the internal domain, the domain is associated with all sites in the organization.
	/// </summary>
	/// <param name="request">The internal domain request object.</param>
	/// <returns>The created internal domain as an <see cref="InternalDomain"/>.</returns>
	[Post("/deployments/v2/internaldomains")]
	Task<InternalDomain> CreateInternalDomainAsync(
		[Body] InternalDomainCreateUpdateRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// List the internal domains.
	/// </summary>
	/// <param name="page">
	/// The page number in the collection.
	/// Defaults to 1 if not specified.
	/// </param>
	/// <param name="limit">
	/// The number of records to return on the page.
	/// Defaults to 100 if not specified.
	/// </param>
	/// <returns>A list of internal domain objects.</returns>
	[Get("/deployments/v2/internaldomains")]
	Task<List<InternalDomain>> ListInternalDomainsAsync(
		int? page = null,
		int? limit = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get an internal domain by its ID.
	/// </summary>
	/// <param name="internalDomainId">The ID of the internal domain.</param>
	/// <returns>The internal domain object.</returns>
	[Get("/deployments/v2/internaldomains/{internalDomainId}")]
	Task<InternalDomain> GetInternalDomainAsync(
		long internalDomainId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Update an internal domain.
	/// </summary>
	/// <param name="internalDomainId">The ID of the internal domain.</param>
	/// <param name="request">The internal domain request object with updated properties.</param>
	/// <returns>The updated internal domain object.</returns>
	[Put("/deployments/v2/internaldomains/{internalDomainId}")]
	Task<InternalDomain> UpdateInternalDomainAsync(
		long internalDomainId,
		[Body] InternalDomainCreateUpdateRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Delete an internal domain.
	/// </summary>
	/// <param name="internalDomainId">The ID of the internal domain to delete.</param>
	/// <returns>A task representing the asynchronous delete operation.</returns>
	[Delete("/internaldomains/{internalDomainId}")]
	Task DeleteInternalDomainAsync(
		long internalDomainId,
		CancellationToken cancellationToken = default);
}
