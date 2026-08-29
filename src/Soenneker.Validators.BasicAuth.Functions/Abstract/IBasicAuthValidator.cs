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
    /// <param name="configuredUsername">Expected username, or null when username validation is disabled.</param>
    /// <param name="configuredPasswordPhc">Expected password hash in PHC format, or null when password validation is disabled.</param>
    /// <returns>true if the supplied credentials match the configured credentials; otherwise, false.</returns>
    bool Validate(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);

    /// <summary>
    /// Validates Basic credentials and returns false instead of throwing when credentials or configuration are invalid.
    /// </summary>
    /// <param name="httpRequestData">http Request Data that defines the request to send.</param>
    /// <param name="configuredUsername">Expected username, or null when username validation is disabled.</param>
    /// <param name="configuredPasswordPhc">Expected password hash in PHC format, or null when password validation is disabled.</param>
    /// <returns>true if the supplied credentials match the configured credentials; otherwise, false.</returns>
    bool ValidateSafe(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);
}
