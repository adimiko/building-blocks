namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class DomainEventCannotBeNullException : BuildingBlocksApplicationException
    {
        internal DomainEventCannotBeNullException() 
            : base("Domain event cannot be null") { }
    }
}
