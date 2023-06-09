namespace BuildingBlocks.Domain.Entities
{
    internal sealed class EntityIdCannotBeEmptyException : BuildingBlocksDomainException
    {
        internal EntityIdCannotBeEmptyException()
            : base("Entity id cannot be empty") { }
    }
}