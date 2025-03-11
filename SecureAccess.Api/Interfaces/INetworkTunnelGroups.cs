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
	/// <param name="offset"></param>
	/// <param name="limit"></param>
	/// <param name="sortBy"></param>
	/// <param name="sortOrder"></param>
	/// <param name="includeStatuses"></param>
	/// <returns></returns>
	[ApiOperationId("listNetworkTunnelGroups")]
	[Get("/networktunnelgroups")]
	Task<NetworkTunnelGroupsList> ListNetworkTunnelGroups(
		[Query] string filters,
		[Query] int offset = 0,
		[Query] int limit = 10,
		[Query] string sortBy = "name",
		[Query] string sortOrder = "asc",
		[Query] bool includeStatuses = false);

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
