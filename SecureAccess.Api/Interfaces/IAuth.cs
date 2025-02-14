using Refit;
using SecureAccess.Api.Data;

namespace SecureAccess.Api.Interfaces;

public interface IAuth
{
	/// <summary>
	/// Creates an authorization token using Basic Authentication.
	/// </summary>
	/// <param name="authorization">Basic Authentication header value.</param>
	/// <returns>
	/// An <see cref="ApiResponse{T}"/> containing the authorization token if successful.
	/// </returns>
	/// <response code="200">Returns the access token upon successful authentication.</response>
	/// <response code="400">Bad Request - The request parameters are invalid.</response>
	/// <response code="401">Unauthorized - Authentication failed due to invalid credentials.</response>
	/// <response code="403">Forbidden - The client does not have permission to access this resource.</response>
	/// <response code="404">Not Found - The requested resource does not exist.</response>
	/// <response code="500">Internal Server Error - An unexpected error occurred on the server.</response>
	[Post("/token")]
	[Headers("Content-Type: application/x-www-form-urlencoded")]
	Task<ApiResponse<AuthResponse>> GetAuthToken(
		[Header("Authorization")] string authorization);
}
