namespace BuildingBlocks.Domain.ValueObjects
{
    public sealed class ValueObjectCannotBeNullException : BuildingBlocksDomainException
    {
        internal ValueObjectCannotBeNullException()
            : base("Value object cannot be null") { }
    }
}