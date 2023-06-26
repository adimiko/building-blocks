namespace Identities.Domain.Credentials
{
    public interface ICredentialRepository
    {
        Task<Credential?> Get(CredentialId id);

        Task Add(Credential credential);
    }
}
