using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TRINV.Infrastructure.Common.Persistance.DatabaseMappings;
using TRINV.Infrastructure.Entities;
using TRINV.Infrastructure.ExternalAssetIntegration;
using TRINV.Infrastructure.Investements;

namespace TRINV.Infrastructure.Common.Persistance;

public class InvestTrackerDbContext : DbContext, IInvestmentDbContext, IExternalAssetIntegrationDbContext
{
    public InvestTrackerDbContext(
        DbContextOptions<InvestTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Investment> Investments { get; set; } = default!;
    public DbSet<IntegrationModel> IntegrationModels { get; set; } = default!;
    public DbSet<IntegrationModelEndpoint> IntegrationModelEndpoints { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //TODO: Check if we ened to configure the mapping manually or the 24 line is working 
        CommonMapping.Configure(builder);

        base.OnModelCreating(builder);
    }
}
