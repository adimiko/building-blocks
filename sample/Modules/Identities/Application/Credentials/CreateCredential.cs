using BuildingBlocks.Application.InternalCommands;
using Identities.Domain.Registrations;

namespace Identities.Application.Credentials
{
    internal sealed record CreateCredentialInternalCommand(RegistrationId Id)  : InternalCommandBase;

    internal sealed class CreateCredentialInternalCommandHandler : IInternalCommandHandler<CreateCredentialInternalCommand>
    {
        public Task Handle(CreateCredentialInternalCommand internalCommand, CancellationToken cancellationToken)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
