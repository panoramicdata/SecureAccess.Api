using Refit;
using SecureAccess.Api.Attributes;
using SecureAccess.Api.Data;
using SecureAccess.Api.Interfaces;

namespace SecureAccess.Api.Extensions;

public static class INetworkTunnelGroupsExtensions
{
	/// <summary>
	/// List the Network Tunnel Groups in the organization.
	/// If you enable the includeStatuses query parameter on your API request, then the status and tunnelsStatus fields are included in the response.
	/// </summary>
	/// <param name="filters"></param>
	/// <param name="sortBy">Specify the field that will be used to sort the items from the collection in the response. default = "name", enum = ["name", "status", "createdAt", "modifiedAt"]</param>
	/// <param name="sortOrder">Specify the sort order (ascending or descending) for the items in the response. example = "asc", default = "asc", enum = ["asc", "desc"]</param>
	/// <param name="includeStatuses">Specify whether to include the IPsec tunnel status fields (status and tunnelsStatus) for each hub. example = true, default = false</param>
	/// <returns></returns>
	[ApiOperationId("listNetworkTunnelGroups")]
	[Get("/networktunnelgroups")]
	public static Task<List<NetworkTunnelGroup>> ListNetworkTunnelGroupsAllAsync(
		this INetworkTunnelGroups networkTunnelGroups,
		string? filters = null,
		string? sortBy = null,
		string? sortOrder = null,
		bool? includeStatuses = null,
		CancellationToken cancellationToken = default)
		=> SecureAccessClient.GetAllAsync(
			(offset, limit, cancellationToken) => networkTunnelGroups.ListNetworkTunnelGroupsAsync(filters, offset, limit, sortBy, sortOrder, includeStatuses, cancellationToken),
			cancellationToken);
}
