using TRINV.Domain.Common.Repositories;
using TRINV.Domain.ExternalAssetIntegration.ExternalResources.Models;

namespace TRINV.Domain.ExternalAssetIntegration.ExternalResources.Repositories;

public interface IIntegrationModelDomainRepository : IDomainRepository<IntegrationModel>
{
    Task<IntegrationModel?> Find(int id, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
    Task<IEnumerable<IntegrationModel>> GetAllByUser(int useId, CancellationToken cancellationToken);
}
