namespace BuildingBlocks.Domain.AggregateRoots
{
    internal sealed class ConcurrencyException : BuildingBlocksDomainException
    {
        internal ConcurrencyException(string message)
            : base(message) { }
    }
}