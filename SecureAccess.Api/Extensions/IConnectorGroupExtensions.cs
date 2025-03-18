using Refit;
using SecureAccess.Api.Data;
using SecureAccess.Api.Interfaces;

namespace SecureAccess.Api.Extensions;

public static class IConnectorGroupExtensions
{
	/// <summary>
	/// List the Resource Connector Groups in the organization. If you include filters on the request, the response is a subset of the Resource Connector Groups in the organization.
	/// </summary>
	/// <param name="connectorGroups"></param>
	/// <param name="includeProvisioningKey">Specify whether to include the Connector Group's provisioning key in the response.</param>
	/// <param name="filters">Filter the list of Connector Groups by one or more properties</param>
	/// <param name="offset">The place to start reading in the collection. The offset starts at 0. If the limit is 10, the offset for the next response is 10. The default value is 0.</param>
	/// <param name="limit">The maximum number of items to return in the response from the collection. The default value is 10.</param>
	/// <param name="sortBy">Specify a field to order the collection. enum = ["name", "connectorsCount", "resourceIds", "createdAt", "modifiedAt"]</param>
	/// <param name="sortOrder">Specify a field in the response to order the collection</param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/deployments/v2/connectorGroups")]
	public static Task<List<ConnectorGroup>> ListConnectorGroupsAllAsync(
		this IConnectorGroups connectorGroups,
		bool? includeProvisioningKey = null,
		string? filters = null,
		string? sortBy = null,
		string? sortOrder = null,
		CancellationToken cancellationToken = default)
		=> SecureAccessClient.GetAllAsync(
			(offset, limit, cancellationToken) => connectorGroups.ListConnectorGroupsAsync(includeProvisioningKey, filters, offset, limit, sortBy, sortOrder, cancellationToken),
			cancellationToken);
}
