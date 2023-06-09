using BuildingBlocks.Application.Commands;
using BuildingBlocks.Application.Queries;

namespace BuildingBlocks.Application.Modules
{
    public interface IModule
    {
        Task Execute(CommandBase command, CancellationToken cancellationToken = default);

        Task<TResult> Execute<TResult>(QueryBase<TResult> query, CancellationToken cancellationToken = default)
            where TResult : DataTransferObject;
    }
}
