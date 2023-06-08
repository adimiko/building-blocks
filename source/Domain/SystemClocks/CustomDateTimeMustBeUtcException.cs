namespace BuildingBlocks.Domain.SystemClocks
{
    public sealed class CustomDateTimeMustBeUtcException : BuildingBlocksDomainException
    {
        internal CustomDateTimeMustBeUtcException() 
            : base("Custom date time must be UTC") { }
    }
}