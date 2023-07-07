namespace BuildingBlocks.Application.InternalCommands
{
    public abstract record InternalCommandBase : IInternalCommandBase
    {
        public Guid CommandId { get; }

        protected InternalCommandBase()
        {
            CommandId = Guid.NewGuid();
        }

        protected InternalCommandBase(Guid id)
        {
            CommandId = id;
        }
    }
}
