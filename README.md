[![](https://img.shields.io/nuget/v/soenneker.validators.basicauth.functions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.basicauth.functions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.basicauth.functions/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.basicauth.functions/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.basicauth.functions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.basicauth.functions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.basicauth.functions/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.basicauth.functions/actions/workflows/codeql.yml)

# Soenneker.Validators.BasicAuth.Functions

Validates Azure Functions isolated-worker Basic Authentication credentials against a fixed-cost username comparison and PBKDF2 PHC password hash.

## Install

```bash
dotnet add package Soenneker.Validators.BasicAuth.Functions
```

## Registration

```csharp
using Soenneker.Validators.BasicAuth.Functions.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddBasicAuthValidatorAsSingleton();
```

The validator is stateless, so singleton registration is appropriate for most function apps. `AddBasicAuthValidatorAsScoped()` is also available.

Configure the expected credential pair:

```json
{
  "BasicAuth": {
    "Username": "integration-client",
    "PasswordPhc": "<PBKDF2 PHC hash>"
  }
}
```

Store the PHC hash in the function app's secret-backed configuration, not the plaintext password.

## Validate an HTTP trigger

```csharp
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Soenneker.Validators.BasicAuth.Functions.Abstract;

public sealed class StatusFunction(IBasicAuthValidator validator)
{
    [Function("Status")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData request)
    {
        if (!validator.ValidateSafe(request))
            return request.CreateResponse(HttpStatusCode.Unauthorized);

        return request.CreateResponse(HttpStatusCode.OK);
    }
}
```

`ValidateSafe` returns `false` when the request lacks parseable Basic credentials or the username/password does not match. Required-configuration failures and invalid PHC data still throw; “safe” applies to request authentication failures, not application misconfiguration.

`Validate` performs the same checks but throws `UnauthorizedAccessException("Invalid credentials")` for request credential failures. Both methods return `true` on success.

## Per-call overrides

```csharp
bool valid = validator.ValidateSafe(
    request,
    configuredUsername: expectedUsername,
    configuredPasswordPhc: expectedPasswordPhc);
```

Overrides take precedence independently. A null argument falls back to `BasicAuth:Username` or `BasicAuth:PasswordPhc`; it does not disable that check.

## Security boundaries

The HTTP trigger is anonymous at the Functions host level in the example because this validator performs the credential check. Ensure every applicable path invokes it before protected work. Require TLS, rate-limit guessable endpoints, and never log the authorization header or plaintext password.

The parser's temporary credential buffer is cleared after every attempt. Usernames use fixed-cost UTF-8 comparison and passwords are verified against PBKDF2 PHC data. The validator does not create a `ClaimsPrincipal`, issue a Basic challenge response, rotate secrets, or replace a full authentication/authorization system.
