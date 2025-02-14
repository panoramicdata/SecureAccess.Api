using SecureAccess.Api.Services;
using System.Net.Http.Headers;

namespace SecureAccess.Api.Authentication;
public class AuthenticationHandler(OAuth2Service authService) : DelegatingHandler
{
	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		// Get a valid access token
		var accessToken = await authService.GetAccessTokenAsync();

		// Add Authorization header
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

		return await base.SendAsync(request, cancellationToken);
	}
}

