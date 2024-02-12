using TRINV.Domain.Common.Models;

namespace TRINV.Application.Common.Events;

public interface IEventHandler<in TEvent>
    where TEvent : IDomainEvent
{
    Task Handle(TEvent domainEvent);
}
