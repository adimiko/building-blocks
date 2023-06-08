namespace BuildingBlocks.Domain.Entities
{
    public sealed class EntityIdCannotBeEmptyException : BuildingBlocksDomainException
    {
        internal EntityIdCannotBeEmptyException()
            : base("Entity id cannot be empty") { }
    }
}