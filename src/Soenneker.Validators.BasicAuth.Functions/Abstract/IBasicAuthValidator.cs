using Microsoft.Azure.Functions.Worker.Http;
using Soenneker.Validators.Validator.Abstract;

namespace Soenneker.Validators.BasicAuth.Functions.Abstract;

/// <summary>
/// A validation module for validating HTTP Basic Authentication credentials in Functions.
/// </summary>
public interface IBasicAuthValidator : IValidator
{
    /// <summary>
    /// Executes the validate operation.
    /// </summary>
    /// <param name="httpRequestData">The http request data.</param>
    /// <param name="configuredUsername">The configured username.</param>
    /// <param name="configuredPasswordPhc">The configured password phc.</param>
    /// <returns>A value indicating whether the operation succeeded.</returns>
    bool Validate(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);

    /// <summary>
    /// Executes the validate safe operation.
    /// </summary>
    /// <param name="httpRequestData">The http request data.</param>
    /// <param name="configuredUsername">The configured username.</param>
    /// <param name="configuredPasswordPhc">The configured password phc.</param>
    /// <returns>A value indicating whether the operation succeeded.</returns>
    bool ValidateSafe(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);
}