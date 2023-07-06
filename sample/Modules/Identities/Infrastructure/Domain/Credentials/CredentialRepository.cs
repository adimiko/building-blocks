using Identities.Domain.Credentials;
using Microsoft.EntityFrameworkCore;

namespace Identities.Infrastructure.Domain.Credentials
{
    internal sealed class CredentialRepository : ICredentialRepository
    {
        private readonly DbSet<Credential> _credentials;

        public CredentialRepository(IdentitiesDbContext context)
        {
            _credentials = context.Credentials;
        }

        public Task Add(Credential credential)
        {
            return _credentials.AddAsync(credential).AsTask();
        }

        public Task<Credential?> Get(CredentialId id)
        {
            return _credentials.FindAsync(id).AsTask();
        }
    }
}
