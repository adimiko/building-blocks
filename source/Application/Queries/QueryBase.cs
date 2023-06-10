namespace BuildingBlocks.Application.Queries
{
    public abstract record QueryBase<TResult> : IQueryBase<TResult>
        where TResult : DataTransferObject
    {
        public Guid Id { get; }

        protected QueryBase()
        {
            Id = Guid.NewGuid();
        }

        protected QueryBase(Guid id)
        {
            Id = id;
        }
    }
}
