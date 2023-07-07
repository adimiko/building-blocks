using Identities.Domain.Registrations;

namespace Identities.Infrastructure.Domain
{
    internal sealed class UniqueLogin : IUniqueLogin
    {
        public bool IsUnique(string login)
        {
            return true;
        }
    }
}
