using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.DomainServices;
using Identities.Domain.AccountProfiles;
using Identities.Domain.Registrations;

namespace Identities.Application.AccountProfiles
{
    internal sealed record CreateAccountProfileInternalCommand(RegistrationId RegistrationId) : InternalCommandBase;

    internal sealed class CreateAccountProfileCommandHandler : IInternalCommandHandler<CreateAccountProfileInternalCommand>
    {
        private readonly IRepository<Registration, RegistrationId> _registrationRepository;

        private readonly IRepository<AccountProfile, AccountProfileId> _accountProfileRepository;

        private readonly AggregateRootExistsCheckerDomainService _aggregateRootExistsCheckerDomainService;

        public CreateAccountProfileCommandHandler(
            IRepository<Registration, RegistrationId> registrationRepository,
            IRepository<AccountProfile, AccountProfileId> accountProfileRepository,
            AggregateRootExistsCheckerDomainService aggregateRootExistsCheckerDomainService) 
        { 
            _registrationRepository = registrationRepository;
            _accountProfileRepository = accountProfileRepository;
            _aggregateRootExistsCheckerDomainService = aggregateRootExistsCheckerDomainService;
        }

        public async Task Handle(CreateAccountProfileInternalCommand command, CancellationToken cancellationToken)
        {
            var registration = await _registrationRepository.Get(command.RegistrationId);

            _aggregateRootExistsCheckerDomainService.Check(registration);

            var accountProfile = registration.CreateAccountProfile();

            await _accountProfileRepository.Add(accountProfile);
        }
    }
}
