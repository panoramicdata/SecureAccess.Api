namespace SecureAccess.Api.DependencyInjection;

public interface ISecureAccessClientFactory
{
	SecureAccessClient CreateClient(SecureAccessClientOptions options);
}