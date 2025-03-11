using Refit;
using SecureAccess.Api.Attributes;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

public interface INetworkTunnelGroups
{
	/// <summary>
	/// List the Network Tunnel Groups in the organization.
	/// If you enable the includeStatuses query parameter on your API request, then the status and tunnelsStatus fields are included in the response.
	/// </summary>
	/// <param name="filters"></param>
	/// <param name="offset">An integer that represents the place to start reading in the collection. When the offset is 0, the first page is returned from the collection. If the limit is 10, the offset for the next page is 10. The default value is 0.</param>
	/// <param name="limit">An integer that represents the number of records to return in the response. The default value is 10.</param>
	/// <param name="sortBy">Specify the field that will be used to sort the items from the collection in the response. default = "name", enum = ["name", "status", "createdAt", "modifiedAt"]</param>
	/// <param name="sortOrder">Specify the sort order (ascending or descending) for the items in the response. example = "asc", default = "asc", enum = ["asc", "desc"]</param>
	/// <param name="includeStatuses">Specify whether to include the IPsec tunnel status fields (status and tunnelsStatus) for each hub. example = true, default = false</param>
	/// <returns></returns>
	[ApiOperationId("listNetworkTunnelGroups")]
	[Get("/networktunnelgroups")]
	Task<NetworkTunnelGroupsList> ListNetworkTunnelGroups(
	[Query] string? filters,
	[Query] int? offset,
	[Query] int? limit,
	[Query] string? sortBy,
	[Query] string? sortOrder,
	[Query] bool? includeStatuses);

	[ApiOperationId("addNetworkTunnelGroup")]
	[Post("/networktunnelgroups")]
	Task<NetworkTunnelGroupResponse> AddNetworkTunnelGroup(
		[Body] NetworkTunnelGroupCreateRequest request);

	[ApiOperationId("getNetworkTunnelGroup")]
	[Get("/networktunnelgroups/{id}")]
	Task<NetworkTunnelGroupResponse> GetNetworkTunnelGroup(int id);

	[ApiOperationId("patchNetworkTunnelGroup")]
	[Patch("/networktunnelgroups/{id}")]
	Task<NetworkTunnelGroupResponse> PatchNetworkTunnelGroup(
		int id, [Body] List<NetworkTunnelGroupPatchOperation> operations);

	[ApiOperationId("deleteNetworkTunnelGroup")]
	[Delete("/networktunnelgroups/{id}")]
	Task DeleteNetworkTunnelGroup(int id);
}
