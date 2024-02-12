using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRINV.Application.Common;
using TRINV.Domain.Common.Repositories;
using TRINV.Infrastructure.Common.Events;
using TRINV.Infrastructure.Common.Persistance;
using TRINV.Infrastructure.ExternalAssetIntegration;
using TRINV.Infrastructure.Investements;

namespace TRINV.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddTransient<IEventDispatcher, EventDispatcher>()
                .AddQueryRepository()
                .AddDomainRepository();

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<InvestTrackerDbContext>(options => options
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer
                        .MigrationsAssembly(typeof(InvestTrackerDbContext).Assembly.FullName))
            .EnableDetailedErrors(true)) // TODO:Don't do this on production. Don't hardcode this
            .AddScoped<IInvestmentDbContext>(provider => provider.GetService<InvestTrackerDbContext>()
                ?? throw new ArgumentNullException("InvestTrackerDbContext was not found"))
            .AddScoped<IExternalAssetIntegrationDbContext>(provider => provider.GetService<InvestTrackerDbContext>()
                ?? throw new ArgumentNullException("InvestTrackerDbContext was not found"));

    internal static IServiceCollection AddQueryRepository(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IQueryRepository<>))
                )
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

    internal static IServiceCollection AddDomainRepository(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IDomainRepository<>))
                )
                .AsSelfWithInterfaces()
                .WithScopedLifetime());
}
