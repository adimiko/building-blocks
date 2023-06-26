using BuildingBlocks.Application.InternalCommands;
using Identities.Domain.Credentials;
using Identities.Domain.Registrations;

namespace Identities.Application.Credentials
{
    internal sealed record CreateCredentialInternalCommand(RegistrationId Id)  : InternalCommandBase;

    internal sealed class CreateCredentialInternalCommandHandler : IInternalCommandHandler<CreateCredentialInternalCommand>
    {
        private readonly IRegistrationRepository _registrationRepository;

        private readonly ICredentialRepository _credentialRepository;

        public CreateCredentialInternalCommandHandler(
            IRegistrationRepository registrationRepository,
            ICredentialRepository credentialRepository)
        {
            _registrationRepository = registrationRepository;
            _credentialRepository = credentialRepository;
        }

        public async Task Handle(CreateCredentialInternalCommand internalCommand, CancellationToken cancellationToken)
        {
            //TODO domain service check entity exists
            var registration = await _registrationRepository.Get(internalCommand.Id);

            var credential = registration.CreateCredential();

            await _credentialRepository.Add(credential);
        }
    }
}
