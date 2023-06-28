using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal interface IDomainEventPublication<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
        IReadOnlyCollection<InternalCommandBase> GetInternalCommands(TDomainEvent domainEvent);
    }
}
