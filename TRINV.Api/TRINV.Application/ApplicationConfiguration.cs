using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TRINV.Application.Common.Events;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Builders.Interfaces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Commands;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces;
using TRINV.Application.ExternalAssetIntegration.ExternalResources.Services.ExtenalIntegrationResouces.Interfaces;
using TRINV.Shared.Business.Helpers.OutputHelper;
using TRINV.Shared.Business.Logger;

namespace TRINV.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(
             this IServiceCollection services)
             => services
                 .AddScoped<IOutputHelper, OutpuHelper>()
                 .AddScoped<ILoggerService, LoggerService>()
                 .AddScoped<IExternalIntegrationResourceService, ExternalIntegrationResourceService>()
                 .AddEventHandlers()
                 .RegisterAllTypes<IExternalIntegrationResourceBuilder>(new[] { typeof(ApplicationConfiguration).Assembly })
                 .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateRequestExternalResourceCommand).Assembly));

    public static IServiceCollection RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
      ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
        foreach (var type in typesFromAssemblies)
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));

        return services;
    }

    private static IServiceCollection AddEventHandlers(this IServiceCollection services)
          => services
              .Scan(scan => scan
                  .FromCallingAssembly()
                  .AddClasses(classes => classes
                      .AssignableTo(typeof(IEventHandler<>)))
                  .AsImplementedInterfaces()
                  .WithTransientLifetime());
}
