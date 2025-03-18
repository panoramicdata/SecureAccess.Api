using Refit;
using SecureAccess.Api.Attributes;
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
	[ApiOperationId("listRoamingComputers")]
	[Get("/deployments/v2/roamingcomputers")]
	Task<List<RoamingComputer>> ListRoamingComputersAsync(
		string? name = null,
		string? status = null,
		string? swgStatus = null,
		DateTime? lastSyncBefore = null,
		DateTime? lastSyncAfter = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Get a specific roaming computer.
	/// </summary>
	/// <param name="deviceId">The unique device ID.</param>
	/// <returns>Roaming computer details.</returns>
	[ApiOperationId("getRoamingComputer")]
	[Get("/deployments/v2/roamingcomputers/{deviceId}")]
	Task<RoamingComputer> GetRoamingComputerAsync(
		string deviceId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Update a roaming computer in the organization.
	/// </summary>
	/// <param name="deviceId">The unique device ID.</param>
	/// <param name="updateRequest">Update request payload.</param>
	/// <returns>Updated roaming computer details.</returns>
	[ApiOperationId("updateRoamingComputer")]
	[Put("/deployments/v2/roamingcomputers/{deviceId}")]
	Task<RoamingComputer> UpdateRoamingComputerAsync(
		string deviceId,
		[Body] RoamingComputerUpdateRequest updateRequest,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Delete a roaming computer in the organization.
	/// </summary>
	/// <param name="deviceId">The unique device ID.</param>
	/// <returns>No content response.</returns>
	[ApiOperationId("deleteRoamingComputer")]
	[Delete("/deployments/v2/roamingcomputers/{deviceId}")]
	Task DeleteRoamingComputerAsync(string deviceId, CancellationToken cancellationToken = default);

	/// <summary>
	/// Get the OrgInfo.json properties for deploying the Cisco Secure Client on user devices in the organization. The Cisco Secure Client with the Internet Security module requires the OrgInfo.json properties
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/deployments/v2/roamingcomputers/orginfo")]
	Task<OrgInfo> GetOrgInfoAsync(CancellationToken cancellationToken = default);
}
