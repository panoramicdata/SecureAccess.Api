using FluentAssertions;
using Neovolve.Logging.Xunit;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit.Abstractions;

namespace SecureAccess.Api.Test.UnitTests;

public class JsonTesting : IDisposable
{
	private readonly ICacheLogger<SecureAccessClient> _logger;
	private readonly WireMockServer _server;

	public JsonTesting(ITestOutputHelper testOutputHelper)
	{
		_logger = testOutputHelper.BuildLoggerFor<SecureAccessClient>();

		_server = WireMockServer.Start();

		_server
			.Given(Request.Create().WithPath("/deployments/v2/networktunnelgroups").UsingGet())
			.RespondWith(
				Response.Create()
				.WithStatusCode(200)
				.WithHeader("Content-Type", "application/json")
				.WithBody(
"""
{
    "data": [
        {
            "id": 4561237892,
            "name": "New York Branch Tunnels",
            "organizationId": 123456,
            "deviceType": "ASA",
            "region": "us-east-1",
            "status": "warning",
            "hubs": [
                {
                    "id": 987654321,
                    "isPrimary": true,
                    "datacenter": {
                        "name": "us-east-1"
                    },
                    "authId": "newyorkbranchtunnels123@123456-987654321.sse.cisco.com"
                },
                {
                    "id": 147852369,
                    "isPrimary": false,
                    "datacenter": {
                        "name": "us-central-1"
                    },
                    "authId": "newyorkbranchtunnels123@123456-147852369.sse.cisco.com"
                }
            ],
            "routing": {
                "type": "static",
                "data": {
                    "networkCIDRs": [
                        "123.111.222.25/24",
                        "111.222.39.1/32"
                    ]
                }
            },
            "createdAt": "2024-06-12T18:04:23Z",
            "modifiedAt": "2024-06-25T15:21:32Z"
        }
    ],
    "offset": 1,
    "limit": 10,
    "total": 1
}
"""));
		_server
			.Given(Request.Create().WithPath("/server").UsingGet())
			.RespondWith(
				Response.Create()
				.WithStatusCode(200)
				.WithHeader("Content-Type", "application/json")
				.WithBody(
""""
{
	"server_name": "TestServer",
	"server_os": "windows"
}
""""));
		_server
			.Given(Request.Create().WithPath("/server_bad1").UsingGet())
			.RespondWith(
				Response.Create()
				.WithStatusCode(200)
				.WithHeader("Content-Type", "application/json")
				.WithBody(
		""""
{
	"server_name": "TestServer",
	"server_os": "fakeos"
}
""""));
	}

	public void Dispose()
	{
		_server.Stop();
		_server.Dispose();
	}

	[Fact]
	public async Task NetworkTunnelGroupsTest()
	{
		using var httpClient = new HttpClient();
		var clientOptions = new SecureAccessClientOptions { ApiUrl = _server.Urls[0] };
		var client = new SecureAccessClient(clientOptions, httpClient);
		var result = await client.Deployments.NetworkTunnelGroups.ListNetworkTunnelGroupsAsync(filters: null, offset: 1, limit: 10, sortBy: null, sortOrder: null, includeStatuses: null);
		_ = await Verify(result);
	}

	[Fact]
	public async Task ServerNumValid()
	{
		using var httpClient = new HttpClient();
		httpClient.BaseAddress = new Uri(_server.Urls[0]);
		var result = await httpClient.GetFromJsonAsync<Server>("/server");
		_ = result.Should().NotBeNull();
		_ = result.Name.Should().Be("TestServer");
		_ = result.ServerOs.Should().Be(OSPlatform.Windows);
		_ = result.ServerOsRaw.Should().Be("windows");
	}

	[Fact]
	public async Task ServerNum_ValueNotInEnum()
	{
		using var httpClient = new HttpClient();
		httpClient.BaseAddress = new Uri(_server.Urls[0]);
		var result = await httpClient.GetFromJsonAsync<Server>("/server_bad1");
		_ = result.Should().NotBeNull();
		_ = result.Name.Should().Be("TestServer");
		_ = result.ServerOs.Should().Be(OSPlatform.Unknown);
		_ = result.ServerOsRaw.Should().Be("fakeos");
	}

	[Fact]
	public void ServerNum_SetRawDirectlyWithMissingEnumValue()
	{
		var server = new Server
		{
			Name = "SomeServer",
			ServerOsRaw = "tizen"
		};
		_ = server.Name.Should().Be("SomeServer");
		_ = server.ServerOs.Should().Be(OSPlatform.Unknown);
		_ = server.ServerOsRaw.Should().Be("tizen");
	}

	[Fact]
	public void ServerNum_SetRawDirectlyWithValidEnumValue()
	{
		var server = new Server
		{
			Name = "SomeServer",
			ServerOsRaw = "linux"
		};
		_ = server.Name.Should().Be("SomeServer");
		_ = server.ServerOs.Should().Be(OSPlatform.Linux);
		_ = server.ServerOsRaw.Should().Be("linux");
	}

}

public class Server
{
	[JsonPropertyName("server_name")]
	public required string Name { get; set; }

	[JsonPropertyName("server_os")]
	public required string ServerOsRaw { get; set; }

	[JsonIgnore]
	public OSPlatform ServerOs
	{
		get => Enum.TryParse<OSPlatform>(ServerOsRaw, ignoreCase: true, out var osPlatform) ? osPlatform : OSPlatform.Unknown;
		set => ServerOsRaw = value.ToString();
	}
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OSPlatform
{
	Unknown,

	[JsonStringEnumMemberName("windows")]
	Windows,

	[JsonStringEnumMemberName("linux")]
	Linux,

	[JsonStringEnumMemberName("macos")]
	MacOS
}