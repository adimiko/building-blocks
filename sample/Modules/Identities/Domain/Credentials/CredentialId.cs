using BuildingBlocks.Domain.AggregateRoots;

namespace Identities.Domain.Credentials
{
    public sealed record CredentialId : AggregateRootId
    {
        public CredentialId(Guid id)
            : base(id) { }
    }
}
