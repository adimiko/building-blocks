namespace Identities.Domain.SheredKernel.Logins
{
    public interface IUniqueLogin
    {
        bool IsUnique(string login);
    }
}
