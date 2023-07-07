using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal interface IDomainEventPublication<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        IReadOnlyCollection<InternalCommandBase> GetInternalCommands(object domainEvent);
    }
}
