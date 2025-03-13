using Refit;
using SecureAccess.Api.Attributes;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

public interface IConnectorGroups
{
	/// <summary>
	/// List the Resource Connector Groups in the organization. If you include filters on the request, the response is a subset of the Resource Connector Groups in the organization.
	/// </summary>
	/// <param name="includeProvisioningKey">Specify whether to include the Connector Group's provisioning key in the response.</param>
	/// <param name="filters">Filter the list of Connector Groups by one or more properties</param>
	/// <param name="offset">The place to start reading in the collection. The offset starts at 0. If the limit is 10, the offset for the next response is 10. The default value is 0.</param>
	/// <param name="limit">The maximum number of items to return in the response from the collection. The default value is 10.</param>
	/// <param name="sortBy">Specify a field to order the collection. enum = ["name", "connectorsCount", "resourceIds", "createdAt", "modifiedAt"]</param>
	/// <param name="sortOrder">Specify a field in the response to order the collection</param>
	/// <returns></returns>
	[ApiOperationId("listConnectorGroups")]
	[Get("/connectorGroups")]
	Task<PagedResponse<ConnectorGroup>> ListConnectorGroupsAsync(
		[Query] bool? includeProvisioningKey,
		[Query] string? filters,
		[Query] int? offset,
		[Query] int? limit,
		[Query] string? sortBy,
		[Query] string? sortOrder,
		CancellationToken cancellationToken = default);

	[Post("/connectorGroups")]
	Task<ConnectorGroup> CreateConnectorGroupAsync([Body] ConnectorGroupCreateUpdateRequest connectorGroup);

	[Get("/connectorGroups/{id}")]
	Task<ConnectorGroup> GetConnectorGroupAsync(
		long id,
		bool includeProvisioningKey = false,
		CancellationToken cancellationToken = default);

	[Put("/connectorGroups/{id}")]
	Task<ConnectorGroup> UpdateConnectorGroupAsync(long id, [Body] ConnectorGroupCreateUpdateRequest connectorGroup);

	[Patch("/connectorGroups/{id}")]
	Task<ConnectorGroup> PatchConnectorGroup(long id, [Body] List<PatchOperation> patchOperations);

	[Delete("/connectorGroups/{id}")]
	Task DeleteConnectorGroup(long id);

	//[Get("/connectorGroups/counts")]
	//Task<ConnectorGroupCountsResponse> GetConnectorGroupCounts();
}
