namespace BuildingBlocks.Domain.Entities
{
    internal sealed class EntityIdCannotBeNullException : BuildingBlocksDomainException
    {
        internal EntityIdCannotBeNullException() 
            : base("Entity id cannot be null") { }
    }
}