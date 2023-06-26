namespace BuildingBlocks.Application.Commands
{
    public abstract record CommandBase : ICommandBase
    {
        public Guid CommandId { get; }

        protected CommandBase()
        {
            CommandId = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            CommandId = id;
        }
    }
}
