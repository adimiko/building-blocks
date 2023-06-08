namespace BuildingBlocks.Domain.Entities
{
    public sealed class EntityIdCannotBeNullException : BuildingBlocksDomainException
    {
        internal EntityIdCannotBeNullException() 
            : base("Entity id cannot be null") { }
    }
}