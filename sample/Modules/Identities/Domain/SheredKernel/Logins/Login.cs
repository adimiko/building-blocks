using BuildingBlocks.Domain.ValueObjects;
using Identities.Domain.SheredKernel.Logins.Rules;

namespace Identities.Domain.SheredKernel.Logins
{
    public sealed record Login : ValueObject
    {
        public string Value { get; }

        private Login(string value)
        {
            Value = value;
        }

        public static Login Of(string value, IUniqueLogin uniqueLogin)
        {
            CheckRule(new LoginMustBeUniqueRule(value, uniqueLogin));

            return new Login(value);
        }

        public static Login Restore(string value)
        {
            return new Login(value);
        }
    }
}
