using Microsoft.Azure.Functions.Worker.Http;
using Soenneker.Validators.Validator.Abstract;

namespace Soenneker.Validators.BasicAuth.Functions.Abstract;

/// <summary>
/// A validation module for validating HTTP Basic Authentication credentials in Functions.
/// </summary>
public interface IBasicAuthValidator : IValidator
{
    bool Validate(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);

    bool ValidateSafe(HttpRequestData httpRequestData, string? configuredUsername = null, string? configuredPasswordPhc = null);
}