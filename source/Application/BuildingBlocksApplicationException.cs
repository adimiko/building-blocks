namespace BuildingBlocks.Application
{
    internal abstract class BuildingBlocksApplicationException : Exception
    {
        internal BuildingBlocksApplicationException(string message)
            : base(message) { }
    }
}
