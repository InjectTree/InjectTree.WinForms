using System;
using Microsoft.Extensions.DependencyInjection;

namespace InjectTree.WinForms;

/// <summary>
/// Extension methods for IServiceCollection to register services using InjectTreeUtilities.
/// </summary>
public static class ServiceCollectionInjectTreeWinFormsExtensions
{
    /// <summary>
    /// Register default services for InjectTree.WinForms.
    /// </summary>
    /// <param name="services">The IServiceCollection to add InjectTree to.</param>
    /// <returns>The IServiceCollection for chaining.</returns>
    public static IServiceCollection AddInjectTreeWinForms(this IServiceCollection services)
    {
        if (services is null)
            throw new ArgumentNullException(nameof(services));

        return services.AddSingleton<IBranchProvider, WinFormsBranchProvider>();
    }
}