using BuildingBlocks.Application.Commands;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.DomainServices;
using Identities.Domain.Registrations;

namespace Identities.Application.Registrations
{
    public sealed record ConfirmCommand(Guid RegistrationId) : CommandBase;

    internal sealed class ConfirmCommandHandler : ICommandHandler<ConfirmCommand>
    {
        private readonly IRepository<Registration, RegistrationId> _registrationRepository;

        private readonly AggregateRootExistsCheckerDomainService _aggregateRootExistsCheckerDomainService;

        public ConfirmCommandHandler(
            IRepository<Registration, RegistrationId> registrationRepository,
            AggregateRootExistsCheckerDomainService aggregateRootExistsCheckerDomainService)
        {
            _registrationRepository = registrationRepository;
            _aggregateRootExistsCheckerDomainService = aggregateRootExistsCheckerDomainService;
        }

        public async Task Handle(ConfirmCommand command, CancellationToken cancellationToken)
        {
            var registration = await _registrationRepository.Get(new RegistrationId(command.RegistrationId));

            _aggregateRootExistsCheckerDomainService.Check(registration);

            registration.Confirm();
        }
    }
}
