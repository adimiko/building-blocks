using BuildingBlocks.Domain.AggregateRoots;

namespace Identities.Domain.Credentials
{
    public sealed record CredentailId : AggregateRootId
    {
        public CredentailId(Guid id)
            : base(id) { }
    }
}
