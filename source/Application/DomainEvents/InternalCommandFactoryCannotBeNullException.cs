namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class InternalCommandFactoryCannotBeNullException : BuildingBlocksApplicationException
    {
        internal InternalCommandFactoryCannotBeNullException() 
            : base("Internal command factory cannot be null") { }
    }
}
