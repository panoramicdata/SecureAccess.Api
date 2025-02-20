namespace SecureAccess.Api.Exceptions;

[Serializable]
internal class SecureAccessApiException : Exception
{
	public SecureAccessApiException()
	{
	}

	public SecureAccessApiException(string? message) : base(message)
	{
	}

	public SecureAccessApiException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}