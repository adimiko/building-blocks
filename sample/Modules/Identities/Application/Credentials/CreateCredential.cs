using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.DomainServices;
using Identities.Domain.Credentials;
using Identities.Domain.Registrations;

namespace Identities.Application.Credentials
{
    internal sealed record CreateCredentialInternalCommand(RegistrationId Id) : InternalCommandBase;

    internal sealed class CreateCredentialInternalCommandHandler : IInternalCommandHandler<CreateCredentialInternalCommand>
    {
        private readonly IRepository<Registration, RegistrationId> _registrationRepository;

        private readonly IRepository<Credential, CredentialId> _credentialRepository;

        private readonly AggregateRootExistsCheckerDomainService _aggregateRootExistsCheckerDomainService;

        public CreateCredentialInternalCommandHandler(
            IRepository<Registration, RegistrationId> registrationRepository,
            IRepository<Credential, CredentialId> credentialRepository,
            AggregateRootExistsCheckerDomainService aggregateRootExistsCheckerDomainService)
        {
            _registrationRepository = registrationRepository;
            _credentialRepository = credentialRepository;
            _aggregateRootExistsCheckerDomainService = aggregateRootExistsCheckerDomainService;
        }

        public async Task Handle(CreateCredentialInternalCommand internalCommand, CancellationToken cancellationToken)
        {
            var registration = await _registrationRepository.Get(internalCommand.Id);

            _aggregateRootExistsCheckerDomainService.Check(registration);

            var credential = registration.CreateCredential();

            await _credentialRepository.Add(credential);
        }
    }
}
