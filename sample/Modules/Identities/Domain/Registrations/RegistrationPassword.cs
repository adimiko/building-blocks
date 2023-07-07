using BuildingBlocks.Domain.ValueObjects;
using Identities.Domain.SheredKernel.Passwords.Rules;

namespace Identities.Domain.Registrations
{
    public sealed record RegistrationPassword : ValueObject
    {
        public string Value { get; }

        private RegistrationPassword(string value)
        {
            Value = value;
        }

        public static RegistrationPassword Of(string value, Func<string, string> calculateHash)
        {
            CheckRule(new PasswordShouldContainAppropriateNumberOfCharacters(value));

            var hashedPassword = calculateHash(value);

            return new RegistrationPassword(hashedPassword);
        }

        public static RegistrationPassword Restore(string value)
        {
            return new RegistrationPassword(value);
        }
    }
}
