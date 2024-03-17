using Microsoft.EntityFrameworkCore;
using TRINV.Infrastructure.Common.Persistance;
using TRINV.Infrastructure.Entities;

namespace TRINV.Infrastructure.ExternalAssetIntegration;

internal interface IExternalAssetIntegrationDbContext : IDbContext
{
    DbSet<RequestExternalResource> RequestExternalResources { get; }
    DbSet<Investment> Investments { get; }
}
