using BuildingBlocks.Domain.AggregateRoots;

namespace BuildingBlocks.Domain.DomainServices
{
    public sealed class AggregateRootExistsCheckerDomainService : DomainService
    {
        public void Check<TAggregateRoot>(TAggregateRoot? aggregateRoot)
            where TAggregateRoot : IAggregateRoot
        {
            CheckRule(new AggregateRootMustExistsBusinessRule<TAggregateRoot>(aggregateRoot));
        }
    }
}
