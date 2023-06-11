namespace Identities.Application.Registrations
{
    public interface IHasher
    {
        string CalculateHash(string value);
    }
}
