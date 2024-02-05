using TRINV.Domain.Common;

namespace TRINV.Application.Common;

public interface IQueryRepository<in TEntity>
      where TEntity : IAggregateRoot
{
}
