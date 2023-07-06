using BuildingBlocks.Domain.BusinessRules;

namespace Identities.Domain.SheredKernel.Passwords.Rules
{
    public sealed class PasswordShouldContainAppropriateNumberOfCharacters : IBusinessDataRule
    {
        private const int _minimumExpectedNumberOfCharacters = 10;

        private readonly string _plainPassword;

        internal PasswordShouldContainAppropriateNumberOfCharacters(string plainPassword)
        {
            _plainPassword = plainPassword;
        }

        public string Message => $"Password should contain {_minimumExpectedNumberOfCharacters} number of characters";

        public bool IsBroken() => _plainPassword.Length < _minimumExpectedNumberOfCharacters;
    }
}
