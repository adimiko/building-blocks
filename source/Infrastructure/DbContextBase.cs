using System.Reflection;
using BuildingBlocks.Infrastructure.IntegrationEvents;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure
{
    public abstract class DbContextBase : DbContext
    {
        internal DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbContextBase(DbContextOptions options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(ApplyConfigurationsFromAssembly());
        }

        protected abstract Assembly ApplyConfigurationsFromAssembly();
    }
}
