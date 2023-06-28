using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal interface IDomainEventPublisher
    {
        Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken)
            where TDomainEvent : DomainEvent;
    }
}
