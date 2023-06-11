using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Credentials.DomainEvents;
using Identities.Domain.SheredKernel.Logins;
using Identities.Domain.SheredKernel.Passwords;

namespace Identities.Domain.Credentials
{
    public sealed class Credential : AggregateRoot<CredentailId, CredentialDomainEventBase>
    {
        private Login _login;

        private Password _password;

        internal static Credential CreateCredentialBasedOnRegistration(
            CredentailId id,
            Login login,
            Password password)
        {
            return new Credential(id, login, password);
        }

        private Credential(
            CredentailId id,
            Login login,
            Password password)
            : base(id)
        {
            CheckNulls(login, password);

            _login = login;
            _password = password;
        }
    }
}
