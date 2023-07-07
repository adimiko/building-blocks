using BuildingBlocks.Application.DomainEvents;
using Identities.Application.AccountProfiles;
using Identities.Application.Credentials;
using Identities.Domain.Registrations.DomainEvents;

namespace Identities.Application.Registrations.DomainEvents
{
    internal sealed class RegistrationConfirmedDomainEventPublication : DomainEventPublication<RegistrationConfirmedDomainEvent>
    {
        public RegistrationConfirmedDomainEventPublication()
        {
            Add(e => new CreateCredentialInternalCommand(e.RegistrationId));
            Add(e => new CreateAccountProfileInternalCommand(e.RegistrationId));
        }
    }
}
