namespace MusicX.Web.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;
using MusicX.Common.Conventions;
using MusicX.Services.Contracts;
using MusicX.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConventionalServices(this IServiceCollection services)
    {
        Type transientServiceInterface = typeof(ITransientService),
            scopedServiceInterface = typeof(IScopedService),
            singletonServiceInterface = typeof(ISingletonService);

        var typesToRegister = GetInterfaceAndImplementationFromAssemblies(typeof(IJudgesService), typeof(IRandomService));

        foreach (var type in typesToRegister)
        {
            if (transientServiceInterface.IsAssignableFrom(type.Interface))
            {
                services.AddTransient(type.Interface, type.Implementation);
            }
            else if (scopedServiceInterface.IsAssignableFrom(type.Interface))
            {
                services.AddScoped(type.Interface, type.Implementation);
            }
            else if (singletonServiceInterface.IsAssignableFrom(type.Interface))
            {
                services.AddSingleton(type.Interface, type.Implementation);
            }
        }

        return services;
    }

    public static IEnumerable<Model> GetInterfaceAndImplementationFromAssemblies(params Type[] typesFromTheAssemblies)
    {
        IEnumerable<Model> result = new List<Model>();

        foreach (var type in typesFromTheAssemblies)
        {
            var publicTypesFromTheAssembly = type
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new Model
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Interface != null);

            result = result.Concat(publicTypesFromTheAssembly);
        }

        return result;
    }
}

public class Model
{
    public Type Interface { get; set; }
    public Type Implementation { get; set; }
}