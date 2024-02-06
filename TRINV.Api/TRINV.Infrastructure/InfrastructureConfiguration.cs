using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TRINV.Application.Common;
using TRINV.Domain.Common.Repositories;
using TRINV.Infrastructure.Common.Persistance;
using TRINV.Infrastructure.Investements;

namespace TRINV.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories();

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<InvestTrackerDbContext>(options => options
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer
                        .MigrationsAssembly(typeof(InvestTrackerDbContext).Assembly.FullName)))
            .AddScoped<IInvestmentDbContext>(provider => provider.GetService<InvestTrackerDbContext>());

    internal static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IDomainRepository<>))
                    .AssignableTo(typeof(IQueryRepository<>))
                )
                .AsImplementedInterfaces()
                .WithTransientLifetime());
}
