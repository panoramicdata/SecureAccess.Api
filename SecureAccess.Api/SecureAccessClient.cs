using Refit;
using SecureAccess.Api.Sections;

namespace SecureAccess.Api;

public partial class SecureAccessClient
{
	private readonly HttpClient _httpClient;
	private readonly RefitSettings _refitSettings;

	public DeploymentsSection Deployments { get; } = new();

	public SecureAccessClient(
		SecureAccessClientOptions clientOptions,
		HttpClient httpClient
		)
	{
		_httpClient = httpClient;
		_httpClient.BaseAddress = new Uri(clientOptions.ApiUrl);
		_refitSettings = new RefitSettings
		{
			UrlParameterFormatter = new RefitUrlParameterFormatter()
		};

		Deployments = new()
		{
			NetworkTunnelGroups = RefitFor(Deployments.NetworkTunnelGroups),
			ConnectorGroups = RefitFor(Deployments.ConnectorGroups),
			RoamingComputers = RefitFor(Deployments.RoamingComputers),
			SwgDeviceSettings = RefitFor(Deployments.SwgDeviceSettings),
			InternalDomains = RefitFor(Deployments.InternalDomains),
			Sites = RefitFor(Deployments.Sites)
		};
	}

	private T RefitFor<T>(T _) => RestService.For<T>(_httpClient, _refitSettings);
}
