using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.AccountProfiles;
using Identities.Domain.Credentials;
using Identities.Domain.Registrations.DomainEvents;

namespace Identities.Domain.Registrations
{
    public sealed class Registration : AggregateRoot<RegistrationId, RegistrationDomainEventBase>
    {
        private RegistrationLogin _login;

        private RegistrationPassword _password;

        private RegistrationStatus _status;

        public static Registration RegisterNewUser(RegistrationLogin login, RegistrationPassword password)
        {
            return new Registration(login, password);
        }

        private Registration(RegistrationLogin login, RegistrationPassword password)
            :base(new RegistrationId(Guid.NewGuid()))
        {
            CheckNulls(login, password);

            _login = login;
            _password = password;

            _status = RegistrationStatus.Pending;
            IncrementVersion();
        }

        public void Confirm()
        {
            _status = RegistrationStatus.Confirmed;

            Publish(new RegistrationConfirmedDomainEvent(Id));
            IncrementVersion();
        }

        public Credential CreateCredential()
        {
            return Credential.CreateCredentialBasedOnRegistration(new CredentialId(Id.Value), _login, _password);
        }

        public AccountProfile CreateAccountProfile()
        {
            var nick = Nick.CreateBasedOnLogin(_login);

            return AccountProfile.CreateBasedOnRegistration(new AccountProfileId(Id.Value), nick);
        }
    }
}
