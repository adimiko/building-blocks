namespace BuildingBlocks.Domain
{
    internal abstract class BuildingBlocksDomainException : Exception
    {
        internal BuildingBlocksDomainException(string message)
            : base(message) { }
    }
}