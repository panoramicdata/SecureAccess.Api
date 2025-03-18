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
	[Get("/deployments/v2/connectorGroups")]
	Task<PagedResponse<ConnectorGroup>> ListConnectorGroupsAsync(
		bool? includeProvisioningKey = null,
		string? filters = null,
		int? offset = null,
		int? limit = null,
		string? sortBy = null,
		string? sortOrder = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Create a Resource Connector Group in the organization
	/// </summary>
	/// <param name="connectorGroup">Create the Connector Group object</param>
	/// <returns></returns>
	[Post("/deployments/v2/connectorGroups")]
	Task<ConnectorGroup> CreateConnectorGroupAsync(
		[Body] ConnectorGroupCreateUpdateRequest connectorGroup,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get the details about a Resource Connector Group
	/// </summary>
	/// <param name="id">The ID of the Connector Group</param>
	/// <param name="includeProvisioningKey">Specify whether to include the Connector Group's provisioning key in the response</param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/deployments/v2/connectorGroups/{id}")]
	Task<ConnectorGroup> GetConnectorGroupAsync(
		long id,
		bool? includeProvisioningKey = false,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Update the name and location properties on the Resource Connector Group
	/// </summary>
	/// <param name="id">The ID of the Connector Group</param>
	/// <param name="connectorGroup">Set the properties on the Resource Connector Group.</param>
	/// <returns></returns>
	[Put("/deployments/v2/connectorGroups/{id}")]
	Task<ConnectorGroup> UpdateConnectorGroupAsync(
		long id,
		[Body] ConnectorGroupCreateUpdateRequest connectorGroup,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Update the name or location properties on the Resource Connector Group, or refresh the Resource Connector Group's provisioning key
	/// </summary>
	/// <param name="id">The ID of the Connector Group</param>
	/// <param name="patchOperations">The Resource Connector Group property. You can set these properties on the Connector Group: name, confirmedAgentsEnabled, provisioningKey, forwardDNS, and resourceIds. enum = ["/name", "/confirmedAgentsEnabled", "/provisioningKey", "/resourceIds", "/forwardDNS"]</param>
	/// <returns></returns>
	[Patch("/deployments/v2/connectorGroups/{id}")]
	Task<ConnectorGroup> PatchConnectorGroupAsync(
		long id,
		[Body] List<PatchOperation> patchOperations,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Delete the Resource Connector Group, including the Connectors in the Resource Connector Group
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[Delete("/deployments/v2/connectorGroups/{id}")]
	Task DeleteConnectorGroupAsync(
		long id,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get the counts of the state information for the Resource Connector Groups
	/// </summary>
	/// <returns></returns>
	[Get("/deployments/v2/connectorGroups/counts")]
	Task<ConnectorGroupCountsResponse> GetConnectorGroupCountsAsync(CancellationToken cancellationToken = default);
}
