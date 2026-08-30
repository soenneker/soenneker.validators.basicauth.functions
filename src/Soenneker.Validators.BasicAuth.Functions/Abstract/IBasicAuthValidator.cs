using Microsoft.Azure.Functions.Worker.Http;
using Soenneker.Validators.Validator.Abstract;

namespace Soenneker.Validators.BasicAuth.Functions.Abstract;

/// <summary>
/// A validation module for validating HTTP Basic Authentication credentials in Functions.
/// </summary>
public interface IBasicAuthValidator : IValidator
{
    /// <summary>
    /// Validates the request Basic credentials against the configured username and password hash.
    /// </summary>
    /// <param name="httpRequestData">http Request Data that defines the request to send.</param>
    /// <param name="configuredUsername">An optional expected username override. When null, <c>BasicAuth:Username</c> is required from configuration.</param>
    /// <param name="configuredPasswordPhc">An optional expected PHC password-hash override. When null, <c>BasicAuth:PasswordPhc</c> is required from configuration.</param>
    /// <returns>true if the supplied credentials match the configured credentials; otherwise, false.</returns>
    bool Validate(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);

    /// <summary>
    /// Validates Basic credentials and returns false instead of throwing for a missing, malformed, or non-matching request credential.
    /// </summary>
    /// <param name="httpRequestData">http Request Data that defines the request to send.</param>
    /// <param name="configuredUsername">An optional expected username override. When null, <c>BasicAuth:Username</c> is required from configuration.</param>
    /// <param name="configuredPasswordPhc">An optional expected PHC password-hash override. When null, <c>BasicAuth:PasswordPhc</c> is required from configuration.</param>
    /// <returns>true if the supplied credentials match the configured credentials; otherwise, false.</returns>
    bool ValidateSafe(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);
}
