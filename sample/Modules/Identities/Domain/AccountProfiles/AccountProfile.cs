using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.AccountProfiles.DomainEvents;

namespace Identities.Domain.AccountProfiles
{
    public sealed class AccountProfile : AggregateRoot<AccountProfileId, AccountProfileDomainEventBase>
    {
        private Nick _nick;

        internal static AccountProfile CreateBasedOnRegistration(
            AccountProfileId id,
            Nick nick)
        {
            return new AccountProfile(id, nick);
        }

        private AccountProfile(
            AccountProfileId id,
            Nick nick)
            : base(id)
        {
            CheckNulls(nick);

            _nick = nick;
        }
    }
}
