using BuildingBlocks.Application.DomainEvents;
using Identities.Application.Credentials;
using Identities.Domain.Registrations.DomainEvents;

namespace Identities.Application.Registrations.DomainEvents
{
    internal sealed class RegistrationConfirmedDomainEventPublication : DomainEventPublication<RegistrationConfirmedDomainEvent>
    {
        public RegistrationConfirmedDomainEventPublication()
        {
            Add(e => new CreateCredentialInternalCommand(e.RegistrationId));
        }
    }
}
