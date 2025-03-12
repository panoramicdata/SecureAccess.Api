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
	Task<PagedResponse<ConnectorGroup>> ListConnectorGroups(
	[Query] bool? includeProvisioningKey,
	[Query] string? filters,
	[Query] int? offset,
	[Query] int? limit,
	[Query] string? sortBy,
	[Query] string? sortOrder);

	//// Create Resource Connector Group
	//// POST /connectorGroups
	//[Post("/connectorGroups")]
	//Task<ConnectorGroupResponse> CreateConnectorGroup([Body] ConnectorGroupReq connectorGroup);

	//// Get Resource Connector Group
	//// GET /connectorGroups/{id}?includeProvisioningKey=...
	//[Get("/connectorGroups/{id}")]
	//Task<ConnectorGroupResponse> GetConnectorGroup(
	//	int id,
	//	[Query] bool includeProvisioningKey = false);

	//// Update Resource Connector Group (PUT)
	//// PUT /connectorGroups/{id}
	//[Put("/connectorGroups/{id}")]
	//Task<ConnectorGroupResponse> UpdateConnectorGroup(int id, [Body] ConnectorGroupReq connectorGroup);

	//// Patch Resource Connector Group
	//// PATCH /connectorGroups/{id}
	//[Patch("/connectorGroups/{id}")]
	//Task<ConnectorGroupResponse> PatchConnectorGroup(int id, [Body] List<PatchOperation> patchOperations);

	//// Delete Resource Connector Group
	//// DELETE /connectorGroups/{id}
	//[Delete("/connectorGroups/{id}")]
	//Task DeleteConnectorGroup(int id);

	//// Get Counts for Connector Groups
	//// GET /connectorGroups/counts
	//[Get("/connectorGroups/counts")]
	//Task<ConnectorGroupCountsResponse> GetConnectorGroupCounts();

	//// =============================
	//// Connector (Agent) Endpoints
	//// =============================

	//// List Connectors
	//// GET /connectorAgents?filters=...&offset=...&limit=...&sortBy=...&sortOrder=...
	//[Get("/connectorAgents")]
	//Task<ConnectorListRes> ListConnectors(
	//	[Query] string filters = null,
	//	[Query] int offset = 0,
	//	[Query] int limit = 10,
	//	[Query(Name = "sortBy")] string sortBy = "originIpAddress",
	//	[Query] string sortOrder = "asc");

	//// Get Connector
	//// GET /connectorAgents/{id}
	//[Get("/connectorAgents/{id}")]
	//Task<ConnectorResponse> GetConnector(int id);

	//// Patch Connector
	//// PATCH /connectorAgents/{id}
	//[Patch("/connectorAgents/{id}")]
	//Task<ConnectorResponse> PatchConnector(int id, [Body] List<PatchOperation> patchOperations);

	//// Delete Connector
	//// DELETE /connectorAgents/{id}
	//[Delete("/connectorAgents/{id}")]
	//Task DeleteConnector(int id);

	//// Get Counts for Connectors
	//// GET /connectorAgents/counts
	//[Get("/connectorAgents/counts")]
	//Task<ConnectorCountsResponse> GetConnectorCounts();
}
