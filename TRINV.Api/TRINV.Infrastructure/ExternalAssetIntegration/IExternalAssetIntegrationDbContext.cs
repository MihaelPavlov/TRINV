using Microsoft.EntityFrameworkCore;
using TRINV.Infrastructure.Common.Persistance;
using TRINV.Infrastructure.Entities;

namespace TRINV.Infrastructure.ExternalAssetIntegration;

internal interface IExternalAssetIntegrationDbContext : IDbContext
{
    DbSet<IntegrationModel> IntegrationModels { get; }
    DbSet<IntegrationModelEndpoint> IntegrationModelEndpoints { get; }
}
