using BuildingBlocks.Domain.AggregateRoots;

namespace Identities.Domain.Registrations
{
    public sealed record RegistrationId : AggregateRootId
    {
        public RegistrationId(Guid id) 
            : base(id){ }
    }
}
