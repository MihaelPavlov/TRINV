using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TRINV.Application.ExternalAssetIntegration.Repositories;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;
using TRINV.Infrastructure.Common.Repositories;

namespace TRINV.Infrastructure.ExternalAssetIntegration.Repositories;

internal class IntegrationModelDomainRepository : DataRepository<IExternalAssetIntegrationDbContext, Entities.IntegrationModel, IntegrationModel>, IIntegrationModelDomainRepository
{
    readonly IMapper mapper;

    public IntegrationModelDomainRepository(IExternalAssetIntegrationDbContext db, IMapper mapper)
        : base(db, mapper)
    {
        this.mapper = mapper;
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var integrationModel = await this.All().AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (integrationModel == null)
            throw new ArgumentNullException($"No integration model with id {id}");

        this.Data.Set<Entities.IntegrationModel>().Remove(integrationModel);
        await this.Data.SaveChangesAsync(cancellationToken);
    }

    public async Task<IntegrationModel?> Find(int id, CancellationToken cancellationToken)
    {
        return await this.All().ProjectTo<IntegrationModel>(this.mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
    }

    public async Task<IEnumerable<IntegrationModel>> GetAllByUser(int useId, CancellationToken cancellationToken)
    => await this.All()
        .ProjectTo<IntegrationModel>(this.mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
}
