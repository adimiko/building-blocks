namespace BuildingBlocks.Domain
{
    public abstract class BuildingBlocksDomainException : Exception
    {
        internal BuildingBlocksDomainException(string message)
            : base(message) { }
    }
}