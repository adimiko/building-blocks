using MediatR;

namespace BuildingBlocks.Application.InternalCommands
{
    public interface IInternalCommandBase : IRequest
    {
        Guid CommandId { get; }
    }
}