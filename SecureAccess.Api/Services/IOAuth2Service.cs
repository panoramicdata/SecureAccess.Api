
namespace SecureAccess.Api.Services;

internal interface IOAuth2Service
{
	Task<string> GetAccessTokenAsync();
}