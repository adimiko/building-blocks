using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain;
using Identities.Domain.AccountProfiles;
using Identities.Domain.Registrations;

namespace Identities.Application.AccountProfiles
{
    internal sealed record CreateAccountProfileInternalCommand(RegistrationId RegistrationId) : InternalCommandBase;

    internal sealed class CreateAccountProfileCommandHandler : IInternalCommandHandler<CreateAccountProfileInternalCommand>
    {
        private readonly IRepository<Registration, RegistrationId> _registrationRepository;

        private readonly IRepository<AccountProfile, AccountProfileId> _accountProfileRepository;

        public CreateAccountProfileCommandHandler(
            IRepository<Registration, RegistrationId> registrationRepository,
            IRepository<AccountProfile, AccountProfileId> accountProfileRepository) 
        { 
            _registrationRepository = registrationRepository;
            _accountProfileRepository = accountProfileRepository;
        }

        public async Task Handle(CreateAccountProfileInternalCommand command, CancellationToken cancellationToken)
        {
            //TODO check exists
            var registration = await _registrationRepository.Get(command.RegistrationId);

            var accountProfile = registration.CreateAccountProfile();

            await _accountProfileRepository.Add(accountProfile);
        }
    }
}
