namespace Identities.Domain.Registrations.DomainEvents
{
    public sealed record RegistrationConfirmedDomainEvent(RegistrationId RegistrationId) : RegistrationDomainEventBase;
}
