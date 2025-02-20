﻿using System.Text.Json.Serialization;

namespace SecureAccess.Api.Data;

public class AuthResponse
{
	[JsonPropertyName("token_type")]
	public string TokenType { get; set; } = string.Empty;

	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; } = string.Empty;

	[JsonPropertyName("expires_in")]
	public int ExpiresIn { get; set; }
}
