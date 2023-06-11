using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Registrations.DomainEvents;
using Identities.Domain.SheredKernel.Logins;
using Identities.Domain.SheredKernel.Passwords;

namespace Identities.Domain.Registrations
{
    public sealed class Registration : AggregateRoot<RegistrationId, RegistrationDomainEventBase>
    {
        private Login _login;

        private Password _password;

        private RegistrationStatus _status;

        public static Registration RegisterNewUser(Login login, Password password)
        {
            return new Registration(login, password);
        }

        private Registration(Login login, Password password)
            :base(new RegistrationId(Guid.NewGuid()))
        {
            CheckNulls(login, password);

            _login = login;
            _password = password;

            _status = RegistrationStatus.Pending;
        }
    }
}
