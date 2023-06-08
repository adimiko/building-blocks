using BuildingBlocks.Domain.ValueObjects;

namespace BuildingBlocks.Domain.Entities
{
    public abstract record EntityId : ValueObject
    {
        public Guid Value { get; }

        protected EntityId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EntityIdCannotBeEmptyException();
            }

            Value = value;
        }
    }
}