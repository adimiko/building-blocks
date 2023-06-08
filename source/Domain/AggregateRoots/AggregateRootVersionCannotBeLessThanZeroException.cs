namespace BuildingBlocks.Domain.AggregateRoots
{
    public sealed class AggregateRootVersionCannotBeLessThanZeroException : BuildingBlocksDomainException
    {
        internal AggregateRootVersionCannotBeLessThanZeroException()
            : base("Aggregate root version cannot be less than zero") { }
    }
}