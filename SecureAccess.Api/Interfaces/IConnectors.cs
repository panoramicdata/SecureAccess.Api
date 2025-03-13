using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

public interface IConnectors
{
	/// <summary>
	/// List the Connectors for the Resource Connector Groups in the organization. If you include query filters on the request, the response is a subset of the Connectors in the organization
	/// </summary>
	/// <param name="filters"></param>
	/// <param name="offset">The place to start reading in the collection. The offset starts at 0. 	If the limit is 10, the offset for the next response is 10. The default value is 0.</param>
	/// <param name="limit">The maximum number of items to return in the response from the collection. The default value is 10</param>
	/// <param name="sortBy">Specify a field to filter the collection.	example = "originIpAddress", default = "originIpAddress", enum = ["instanceId", "originIpAddress", "createdAt", "modifiedAt"]</param>
	/// <param name="sortOrder">Specify a field in the response to order the collection. example = "desc", default = "asc", enum = ["asc", "desc"]</param>
	/// <returns></returns>
	[Get("/connectorAgents")]
	Task<PagedResponse<Connector>> ListConnectors(
	string? filters = null,
	int? offset = null,
	int? limit = null,
	string? sortBy = null,
	string? sortOrder = null);

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
