using BuildingBlocks.Domain.BusinessRules;

namespace Identities.Domain.SheredKernel.Logins.Rules
{
    public sealed class LoginMustBeUniqueRule : IBusinessDataRule
    {
        private readonly string _login;
        private readonly IUniqueLogin _uniqueLogin;

        internal LoginMustBeUniqueRule(string login, IUniqueLogin uniqueLogin)
        {
            _login = login;
            _uniqueLogin = uniqueLogin;
        }

        public string Message => "Login must be unique";

        public bool IsBroken() => !_uniqueLogin.IsUnique(_login);
    }
}
