namespace BuildingBlocks.Application.Queries
{
    public abstract record QueryBase<TResult> : IQueryBase<TResult>
        where TResult : DataTransferObject
    {
        public Guid QueryId { get; }

        protected QueryBase()
        {
            QueryId = Guid.NewGuid();
        }

        protected QueryBase(Guid id)
        {
            QueryId = id;
        }
    }
}
