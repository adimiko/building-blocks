using MediatR;

namespace BuildingBlocks.Application.Commands
{
    public interface ICommandBase : IRequest
    {
        Guid Id { get; }
    }
}
