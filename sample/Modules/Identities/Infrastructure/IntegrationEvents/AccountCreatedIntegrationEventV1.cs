using BuildingBlocks.Infrastructure.IntegrationEvents;
using Identities.Domain.Registrations.DomainEvents;

namespace Identities.Infrastructure.IntegrationEvents
{
    public sealed record AccountCreatedIntegrationEventV1 : IntegrationEvent<RegistrationConfirmedDomainEvent>
    {
        //TODO properties
        public AccountCreatedIntegrationEventV1(RegistrationConfirmedDomainEvent domainEvent) 
            : base(domainEvent)
        { }
    }
}