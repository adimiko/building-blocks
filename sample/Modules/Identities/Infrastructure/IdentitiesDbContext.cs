using BuildingBlocks.Infrastructure;
using Identities.Domain.Credentials;
using Identities.Domain.Registrations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Identities.Infrastructure
{
    public sealed class IdentitiesDbContext : DbContextBase
    {
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Credential> Credentials { get; set; }

        public IdentitiesDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override Assembly ApplyConfigurationsFromAssembly()
            => InfrastructureAssembly.Assembly;
    }
}
