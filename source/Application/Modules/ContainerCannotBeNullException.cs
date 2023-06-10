namespace BuildingBlocks.Application.Modules
{
    internal sealed class ContainerCannotBeNullException : BuildingBlocksApplicationException
    {
        internal ContainerCannotBeNullException() 
            : base("Container cannot be null") { }
    }
}
