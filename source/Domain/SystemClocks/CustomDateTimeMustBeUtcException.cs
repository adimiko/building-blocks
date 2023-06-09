namespace BuildingBlocks.Domain.SystemClocks
{
    internal sealed class CustomDateTimeMustBeUtcException : BuildingBlocksDomainException
    {
        internal CustomDateTimeMustBeUtcException() 
            : base("Custom date time must be UTC") { }
    }
}