using BuildingBlocks.Domain.AggregateRoots;

namespace Identities.Domain.AccountProfiles
{
    public sealed record AccountProfileId : AggregateRootId
    {
        public AccountProfileId(Guid id)
            : base(id) { }
    }
}
