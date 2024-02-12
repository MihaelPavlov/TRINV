using TRINV.Domain.Common.Models;

namespace TRINV.Infrastructure.Common.Events;

internal interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent);
}
