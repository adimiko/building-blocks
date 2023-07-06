using BuildingBlocks.Domain.ValueObjects;
using Identities.Domain.AccountProfiles;
using Identities.Domain.Registrations.Rules;

namespace Identities.Domain.Registrations
{
    public sealed record RegistrationLogin : ValueObject
    {
        public string Value { get; }

        private RegistrationLogin(string value)
        {
            Value = value;
        }

        public static RegistrationLogin Of(string value, IUniqueLogin uniqueLogin)
        {
            CheckRule(new LoginMustBeUniqueRule(value, uniqueLogin));

            return new RegistrationLogin(value);
        }

        public static RegistrationLogin Restore(string value)
        {
            return new RegistrationLogin(value);
        }
    }
}
