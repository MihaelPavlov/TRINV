using Microsoft.Extensions.DependencyInjection;
using TRINV.Domain.Common;
using TRINV.Domain.Common.Mapping;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Services;

namespace TRINV.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .AddFactories()
                .AddInitialMapping()
                .AddTransient<IMappingInitializer, MappingInitializer>()
                .AddTransient<IExternalAssetsService, ExternalAssetsService>();

    private static IServiceCollection AddFactories(this IServiceCollection services)
     => services
         .Scan(scan => scan
             .FromCallingAssembly()
             .AddClasses(classes => classes
                 .AssignableTo(typeof(IFactory<>)))
             .AsMatchingInterface()
             .WithTransientLifetime());

    private static IServiceCollection AddInitialMapping(this IServiceCollection services)
       => services
           .Scan(scan => scan
               .FromCallingAssembly()
               .AddClasses(classes => classes
                   .AssignableTo(typeof(IInitialMapping)))
               .AsImplementedInterfaces()
               .WithTransientLifetime());
}
