using BuildingBlocks.Application.Commands;
using MediatR;

namespace BuildingBlocks.Application.InternalCommands
{
    public interface IInternalCommandHandler<in TInternalCommand> : IRequestHandler<TInternalCommand>
        where TInternalCommand : InternalCommandBase
    {
        new Task Handle(TInternalCommand internalCommand, CancellationToken cancellationToken);
    }
}
