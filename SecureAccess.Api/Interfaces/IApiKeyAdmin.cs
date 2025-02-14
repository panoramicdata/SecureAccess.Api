using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

// TODO - I'm unable to add an API key with the "admin.apikeys:*" scope, so I can't test the ApiKey endpoint

/// <summary>
/// Interface for managing API keys in Cisco Secure Access.
/// </summary>
public interface IApiKeyAdmin
{
	/// <summary>
	/// Retrieves a list of API keys.
	/// </summary>
	/// <param name="offset">The place to start reading in the collection (default 0).</param>
	/// <param name="limit">The number of items to return in the page (default 0, no limit).</param>
	/// <returns>List of API keys.</returns>
	/// <response code="200">Returns the list of API keys.</response>
	/// <response code="401">Unauthorized - Invalid authentication credentials.</response>
	/// <response code="403">Forbidden - Insufficient permissions.</response>
	/// <response code="503">Service Unavailable - Try again later.</response>
	[Get("/apiKeys")]
	Task<ApiResponse<ApiKeyListResponse>> GetApiKeys(
		[AliasAs("offset")] int offset = 0,
		[AliasAs("limit")] int limit = 100);

	/// <summary>
	/// Creates a new API key.
	/// </summary>
	/// <param name="request">The request body containing API key details.</param>
	/// <returns>The created API key with a secret.</returns>
	/// <response code="201">API key successfully created.</response>
	/// <response code="401">Unauthorized - Invalid authentication credentials.</response>
	/// <response code="403">Forbidden - Insufficient permissions.</response>
	/// <response code="409">Conflict - API key with the same name already exists.</response>
	/// <response code="415">Unsupported Media Type.</response>
	/// <response code="503">Service Unavailable - Try again later.</response>
	[Post("/apiKeys")]
	Task<ApiResponse<ApiKeyResponse>> CreateApiKey([Body] ApiKeyRequest request);

	/// <summary>
	/// Retrieves details of a specific API key.
	/// </summary>
	/// <param name="apiKeyId">The ID of the API key.</param>
	/// <returns>API key details.</returns>
	/// <response code="200">Returns the API key details.</response>
	/// <response code="401">Unauthorized.</response>
	/// <response code="403">Forbidden.</response>
	/// <response code="404">Not Found.</response>
	/// <response code="503">Service Unavailable.</response>
	[Get("/apiKeys/{apiKeyId}")]
	Task<ApiResponse<ApiKeyResponse>> GetApiKey([AliasAs("apiKeyId")] string apiKeyId);

	/// <summary>
	/// Updates an existing API key.
	/// </summary>
	/// <param name="apiKeyId">The ID of the API key.</param>
	/// <param name="request">The request body containing updated fields.</param>
	/// <returns>The updated API key.</returns>
	/// <response code="200">API key updated successfully.</response>
	/// <response code="401">Unauthorized.</response>
	/// <response code="403">Forbidden.</response>
	/// <response code="404">Not Found.</response>
	/// <response code="415">Unsupported Media Type.</response>
	/// <response code="503">Service Unavailable.</response>
	[Patch("/apiKeys/{apiKeyId}")]
	Task<ApiResponse<ApiKeyResponse>> UpdateApiKey(
		[AliasAs("apiKeyId")] string apiKeyId,
		[Body] ApiKeyRequest request);

	/// <summary>
	/// Deletes an API key.
	/// </summary>
	/// <param name="apiKeyId">The ID of the API key.</param>
	/// <returns>Void response.</returns>
	/// <response code="204">API key deleted successfully.</response>
	/// <response code="401">Unauthorized.</response>
	/// <response code="403">Forbidden.</response>
	/// <response code="404">Not Found.</response>
	/// <response code="503">Service Unavailable.</response>
	[Delete("/apiKeys/{apiKeyId}")]
	Task<ApiResponse<object>> DeleteApiKey([AliasAs("apiKeyId")] string apiKeyId);

	/// <summary>
	/// Refreshes an API key.
	/// </summary>
	/// <param name="apiKeyId">The ID of the API key to refresh.</param>
	/// <returns>The refreshed API key details.</returns>
	/// <response code="200">API key refreshed successfully.</response>
	/// <response code="401">Unauthorized.</response>
	/// <response code="403">Forbidden.</response>
	/// <response code="404">Not Found.</response>
	/// <response code="415">Unsupported Media Type.</response>
	/// <response code="503">Service Unavailable.</response>
	[Post("/apiKeys/{apiKeyId}/refresh")]
	Task<ApiResponse<ApiKeyResponse>> RefreshApiKey([AliasAs("apiKeyId")] string apiKeyId);
}
