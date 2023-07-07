using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Registrations;

namespace Identities.Domain.Credentials
{
    public sealed record CredentialId : AggregateRootId
    {
        public CredentialId(Guid id)
            : base(id) { }

        public CredentialId(RegistrationId registrationId)
            : base(registrationId.Value) { }
    }
}
