using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Domain.BusinessRules;

namespace BuildingBlocks.Domain.DomainServices
{
    internal class AggregateRootMustExistsBusinessRule<TAggregateRoot> : IBusinessOperationRule
        where TAggregateRoot : IAggregateRoot
    {
        private readonly TAggregateRoot? _aggregateRoot;

        internal AggregateRootMustExistsBusinessRule(TAggregateRoot? aggregateRoot)
        {
            _aggregateRoot = aggregateRoot;
        }

        public string Message => $"{typeof(TAggregateRoot).Name} does not exist";

        public bool IsBroken() => _aggregateRoot is null;
    }
}
