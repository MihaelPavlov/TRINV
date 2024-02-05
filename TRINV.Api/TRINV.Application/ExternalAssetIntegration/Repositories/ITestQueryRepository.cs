using TRINV.Application.Common;
using TRINV.Domain.ExternalAssetIntegration.Dashboard.Models;

namespace TRINV.Application.ExternalAssetIntegration.Repositories
{
    public interface ITestQueryRepository : IQueryRepository<Investment>
    {
        Task<IEnumerable<Investment>> GetAll();
    }
}
