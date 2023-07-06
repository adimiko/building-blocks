using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Credentials.DomainEvents;
using Identities.Domain.Registrations;

namespace Identities.Domain.Credentials
{
    public sealed class Credential : AggregateRoot<CredentialId, CredentialDomainEventBase>
    {
        private RegistrationLogin _login; //TODO change registrationLogin name and password

        private RegistrationPassword _password;

        internal static Credential CreateCredentialBasedOnRegistration(
            CredentialId id,
            RegistrationLogin login,
            RegistrationPassword password)
        {
            return new Credential(id, login, password);
        }

        private Credential(
            CredentialId id,
            RegistrationLogin login,
            RegistrationPassword password)
            : base(id)
        {
            CheckNulls(login, password);

            _login = login;
            _password = password;
        }
    }
}
