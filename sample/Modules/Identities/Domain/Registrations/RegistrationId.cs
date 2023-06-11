using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Credentials;

namespace Identities.Domain.Registrations
{
    public sealed record RegistrationId : AggregateRootId
    {
        public RegistrationId(Guid id) 
            : base(id){ }

        public CredentailId CreateCredentailId()
        {
            return new CredentailId(Value);
        }
    }
}
