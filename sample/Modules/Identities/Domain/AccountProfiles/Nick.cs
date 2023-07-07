using BuildingBlocks.Domain.ValueObjects;
using Identities.Domain.Registrations;

namespace Identities.Domain.AccountProfiles
{
    public sealed record Nick : ValueObject
    {
        public string Value { get; }

        private Nick(string value) 
        {
            Value = value;
        }

        internal static Nick CreateBasedOnLogin(RegistrationLogin login)
        {
            return new Nick(login.Value);
        }

        public static Nick Restore(string value) 
        {
            return new Nick(value);
        }
    }
}
