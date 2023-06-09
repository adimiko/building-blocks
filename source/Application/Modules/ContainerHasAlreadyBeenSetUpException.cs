namespace BuildingBlocks.Application.Modules
{
    internal sealed class ContainerHasAlreadyBeenSetUpException : BuildingBlocksApplicationException
    {
        internal ContainerHasAlreadyBeenSetUpException()
            : base("Container has already been set up") { }
    }
}
