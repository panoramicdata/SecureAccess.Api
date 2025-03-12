using Refit;
using System.Reflection;

namespace SecureAccess.Api;

/// <summary>
/// Custom URL parameter formatter for Refit.
/// It ensures that boolean values are formatted as lowercase strings.
/// </summary>
public class RefitUrlParameterFormatter : DefaultUrlParameterFormatter
{
	public override string? Format(object? parameterValue, ICustomAttributeProvider attributeProvider, Type type)
		=> parameterValue is bool
			? parameterValue.ToString().ToLower()
			: base.Format(parameterValue, attributeProvider, type);
}
