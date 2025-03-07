using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;
public interface IRoamingComputers
{
	/// <summary>
	/// List the roaming computers.
	/// </summary>
	/// <param name="name">Filter by name (optional).</param>
	/// <param name="status">Filter by status (optional).</param>
	/// <param name="swgStatus">Filter by SWG status (optional).</param>
	/// <param name="lastSyncBefore">Filter by last sync before a date (optional).</param>
	/// <param name="lastSyncAfter">Filter by last sync after a date (optional).</param>
	/// <returns>List of roaming computers.</returns>
	[Get("/deployments/v2/roamingcomputers")]
	Task<ApiResponse<List<RoamingComputer>>> ListRoamingComputers(
		[Query] string? name = null,
		[Query] string? status = null,
		[Query] string? swgStatus = null,
		[Query] DateTime? lastSyncBefore = null,
		[Query] DateTime? lastSyncAfter = null
	);

	/// <summary>
	/// Get a specific roaming computer.
	/// </summary>
	/// <param name="deviceId">The unique device ID.</param>
	/// <returns>Roaming computer details.</returns>
	[Get("/deployments/v2/roamingcomputers/{deviceId}")]
	Task<ApiResponse<RoamingComputer>> GetRoamingComputer([AliasAs("deviceId")] string deviceId);

	/// <summary>
	/// Update the name of a roaming computer.
	/// </summary>
	/// <param name="deviceId">The unique device ID.</param>
	/// <param name="updateRequest">Update request payload.</param>
	/// <returns>Updated roaming computer details.</returns>
	[Put("/deployments/v2/roamingcomputers/{deviceId}")]
	Task<ApiResponse<RoamingComputer>> UpdateRoamingComputer(
		[AliasAs("deviceId")] string deviceId,
		[Body] RoamingComputerUpdateRequest updateRequest
	);

	/// <summary>
	/// Delete a roaming computer.
	/// </summary>
	/// <param name="deviceId">The unique device ID.</param>
	/// <returns>No content response.</returns>
	[Delete("/deployments/v2/roamingcomputers/{deviceId}")]
	Task DeleteRoamingComputer([AliasAs("deviceId")] string deviceId);
}
