using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Registrations;

namespace Identities.Domain.AccountProfiles
{
    public sealed record AccountProfileId : AggregateRootId
    {
        public AccountProfileId(Guid id)
            : base(id) { }

        public AccountProfileId(RegistrationId registrationId)
            : base(registrationId.Value) { }
    }
}
