namespace Identities.Domain.Registrations
{
    public interface IUniqueLogin
    {
        bool IsUnique(string login);
    }
}
