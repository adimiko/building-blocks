using MediatR;

namespace BuildingBlocks.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : QueryBase<TResult>
        where TResult : DataTransferObject
    {
        new Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
