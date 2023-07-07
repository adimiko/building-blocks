namespace Identities.Application.SeedWorks
{
    public interface IHasher
    {
        string CalculateHash(string value);
    }
}
