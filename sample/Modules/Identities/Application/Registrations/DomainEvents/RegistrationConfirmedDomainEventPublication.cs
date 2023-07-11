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
            Execute(e => new CreateCredentialInternalCommand(e.RegistrationId));
            Execute(e => new CreateAccountProfileInternalCommand(e.RegistrationId));
        }
    }
}
