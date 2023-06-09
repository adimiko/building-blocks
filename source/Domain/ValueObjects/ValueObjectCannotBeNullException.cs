namespace BuildingBlocks.Domain.ValueObjects
{
    internal sealed class ValueObjectCannotBeNullException : BuildingBlocksDomainException
    {
        internal ValueObjectCannotBeNullException()
            : base("Value object cannot be null") { }
    }
}