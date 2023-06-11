using BuildingBlocks.Domain.ValueObjects;
using Identities.Domain.SheredKernel.Passwords.Rules;

namespace Identities.Domain.SheredKernel.Passwords
{
    public sealed record Password : ValueObject
    {
        public string Value { get; }

        private Password(string value)
        {
            Value = value;
        }

        public static Password Of(string value, Func<string, string> calculateHash)
        {
            CheckRule(new PasswordShouldContainAppropriateNumberOfCharacters(value));

            var hashedPassword = calculateHash(value);

            return new Password(hashedPassword);
        }

        public static Password Restore(string value)
        {
            return new Password(value);
        }
    }
}
