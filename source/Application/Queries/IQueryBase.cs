using MediatR;

namespace BuildingBlocks.Application.Queries
{
    public interface IQueryBase<out TResult> : IRequest<TResult>
        where TResult : DataTransferObject
    {
        Guid QueryId { get; }
    }
}
