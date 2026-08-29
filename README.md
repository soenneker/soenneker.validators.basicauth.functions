[![](https://img.shields.io/nuget/v/soenneker.validators.basicauth.functions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.basicauth.functions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.basicauth.functions/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.validators.basicauth.functions/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.validators.basicauth.functions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.validators.basicauth.functions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.validators.basicauth.functions/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.validators.basicauth.functions/actions/workflows/codeql.yml)

# Soenneker.Validators.BasicAuth.Functions

A validation module for validating HTTP Basic Authentication credentials in Functions.

## Install

```bash
dotnet add package Soenneker.Validators.BasicAuth.Functions
```

## Quick start

```csharp
using Soenneker.Validators.BasicAuth.Functions.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddBasicAuthValidatorAsSingleton();
```

Adds `IBasicAuthValidator` as a singleton service.

## What you get

- `IBasicAuthValidator` — A validation module for validating HTTP Basic Authentication credentials in Functions.
- `BasicAuthValidatorRegistrar` — A validation module for validating HTTP Basic Authentication credentials in Functions.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IBasicAuthValidator.Validate(httpRequestData, configuredUsername, configuredPasswordPhc)` | Validates the request Basic credentials against the configured username and password hash. | true if the supplied credentials match the configured credentials; otherwise, false. |
| `IBasicAuthValidator.ValidateSafe(httpRequestData, configuredUsername, configuredPasswordPhc)` | Validates Basic credentials and returns false instead of throwing when credentials or configuration are invalid. | true if the supplied credentials match the configured credentials; otherwise, false. |
| `BasicAuthValidatorRegistrar.AddBasicAuthValidatorAsSingleton(services)` | Adds `IBasicAuthValidator` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `BasicAuthValidatorRegistrar.AddBasicAuthValidatorAsScoped(services)` | Adds `IBasicAuthValidator` as a scoped service. | The same service collection, so additional registrations can be chained. |
