using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;
using TRINV.Infrastructure.Common.Repositories;

namespace TRINV.Infrastructure.ExternalAssetIntegration.Repositories;

internal class RequestExternalResourceRepository : DataRepository<IExternalAssetIntegrationDbContext, Entities.RequestExternalResource, RequestExternalResource>, IRequestExternalResourceDomainRepository
{
    readonly IMapper mapper;

    public RequestExternalResourceRepository(IExternalAssetIntegrationDbContext db, IMapper mapper)
        : base(db, mapper)
    {
        this.mapper = mapper;
    }

    public async Task<RequestExternalResource?> FindAsync(Expression<Func<RequestExternalResource, bool>> predicate, CancellationToken cancellationToken)
    {
        return await this.All()
            .AsTracking()
            .ProjectTo<RequestExternalResource>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IEnumerable<RequestExternalResource>> AllAsync(CancellationToken cancellationToken)
     => await this.All()
        .ProjectTo<RequestExternalResource>(this.mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

    public async Task<IEnumerable<RequestExternalResource>> GetAllByUserAsync(int useId, CancellationToken cancellationToken)
    => await this.All()
        .ProjectTo<RequestExternalResource>(this.mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
}
