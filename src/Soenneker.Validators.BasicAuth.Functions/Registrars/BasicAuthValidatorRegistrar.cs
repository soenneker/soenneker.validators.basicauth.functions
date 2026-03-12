using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Validators.BasicAuth.Functions.Abstract;

namespace Soenneker.Validators.BasicAuth.Functions.Registrars;

/// <summary>
/// A validation module for validating HTTP Basic Authentication credentials in Functions.
/// </summary>
public static class BasicAuthValidatorRegistrar
{
    /// <summary>
    /// Adds <see cref="IBasicAuthValidator"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddBasicAuthValidatorAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IBasicAuthValidator, BasicAuthValidator>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IBasicAuthValidator"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddBasicAuthValidatorAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IBasicAuthValidator, BasicAuthValidator>();

        return services;
    }
}
