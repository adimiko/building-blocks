using BuildingBlocks.Application.Commands;
using BuildingBlocks.Domain;
using Identities.Domain.Registrations;

namespace Identities.Application.Registrations
{
    public sealed record ConfirmCommand(Guid RegistrationId) : CommandBase;

    internal sealed class ConfirmCommandHandler : ICommandHandler<ConfirmCommand>
    {
        private readonly IRepository<Registration, RegistrationId> _registrationRepository;

        public ConfirmCommandHandler(IRepository<Registration, RegistrationId> registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task Handle(ConfirmCommand command, CancellationToken cancellationToken)
        {
            //TODO domain service check entity exists
            var registration = await _registrationRepository.Get(new RegistrationId(command.RegistrationId));

            registration.Confirm();
        }
    }
}
