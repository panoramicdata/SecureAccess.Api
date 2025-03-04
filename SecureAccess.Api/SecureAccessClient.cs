using Microsoft.Extensions.Logging;
using Refit;
using SecureAccess.Api.Sections;

namespace SecureAccess.Api;

public class SecureAccessClient
{
	private readonly HttpClient _httpClient;

	public DeploymentsSection Deployments { get; } = new();

	public SecureAccessClient(
		SecureAccessClientOptions clientOptions,
		HttpClient httpClient,
		ILogger<SecureAccessClient> logger
		)
	{
		_httpClient = httpClient;
		_httpClient.BaseAddress = new Uri(clientOptions.ApiUrl);

		Deployments = new()
		{
			RoamingComputers = RefitFor(Deployments.RoamingComputers)
		};
	}

	private T RefitFor<T>(T _) => RestService.For<T>(_httpClient);
}
