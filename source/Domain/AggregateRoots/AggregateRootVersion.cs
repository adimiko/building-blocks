using BuildingBlocks.Domain.ValueObjects;

namespace BuildingBlocks.Domain.AggregateRoots
{
    public sealed record AggregateRootVersion : ValueObject
    {
        public int Value { get; }

        private AggregateRootVersion()
        {
            Value = -1;
        }

        private AggregateRootVersion(int value)
        {
            if (value < 0)
            {
                throw new AggregateRootVersionCannotBeLessThanZeroException();
            }

            Value = value;
        }

        public static AggregateRootVersion Restore(int value)
        {
            return new AggregateRootVersion(value);
        }

        internal static AggregateRootVersion Init()
        {
            return new AggregateRootVersion();
        }

        internal AggregateRootVersion Increment()
        {
            return new AggregateRootVersion(Value + 1);
        }
    }
}