namespace BuildingBlocks.Infrastructure.Commands.UnitOfWorks
{
    internal interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
