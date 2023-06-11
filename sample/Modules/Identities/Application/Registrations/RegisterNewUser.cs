using BuildingBlocks.Application.Commands;
using Identities.Domain.Registrations;
using Identities.Domain.SheredKernel.Logins;
using Identities.Domain.SheredKernel.Passwords;

namespace Identities.Application.Registrations
{
    public sealed record RegisterNewUserCommand(string Login, string Password) : CommandBase;

    internal sealed class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand>
    {
        private readonly IUniqueLogin _uniqueLogin;

        private readonly IHasher _hasher;

        private readonly IRegistrationRepository _registrationRepository;

        public RegisterNewUserCommandHandler(
            IUniqueLogin uniqueLogin,
            IHasher hasher,
            IRegistrationRepository registrationRepository)
        {
            _uniqueLogin = uniqueLogin;
            _hasher = hasher;
            _registrationRepository = registrationRepository;
        }

        public async Task Handle(RegisterNewUserCommand command, CancellationToken cancellationToken)
        {

            var login = Login.Of(command.Login, _uniqueLogin);
            var password = Password.Of(command.Password, plainPassword => _hasher.CalculateHash(plainPassword));

            var registration = Registration.RegisterNewUser(login, password);

            await _registrationRepository.Add(registration);
        }
    }
}
