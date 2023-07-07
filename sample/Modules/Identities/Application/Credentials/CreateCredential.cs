using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Domain;
using Identities.Domain.Credentials;
using Identities.Domain.Registrations;

namespace Identities.Application.Credentials
{
    internal sealed record CreateCredentialInternalCommand(RegistrationId RegistrationId) : InternalCommandBase;

    internal sealed class CreateCredentialInternalCommandHandler : IInternalCommandHandler<CreateCredentialInternalCommand>
    {
        private readonly IRepository<Registration, RegistrationId> _registrationRepository;

        private readonly IRepository<Credential, CredentialId> _credentialRepository;

        public CreateCredentialInternalCommandHandler(
            IRepository<Registration, RegistrationId> registrationRepository,
            IRepository<Credential, CredentialId> credentialRepository)
        {
            _registrationRepository = registrationRepository;
            _credentialRepository = credentialRepository;
        }

        public async Task Handle(CreateCredentialInternalCommand internalCommand, CancellationToken cancellationToken)
        {
            var credential = await _credentialRepository.Get(new CredentialId(internalCommand.RegistrationId));

            if (credential is not null)
            {
                return;
            }

            var registration = await _registrationRepository.Get(internalCommand.RegistrationId);

            credential = registration.CreateCredential();

            await _credentialRepository.Add(credential);
        }
    }
}
