using BuildingBlocks.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BuildingBlocks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.AggregateRoots
{
    public abstract class AggregateRootConfiguration<TAggregateRoot> : IEntityTypeConfiguration<TAggregateRoot>
        where TAggregateRoot : Entity, IAggregateRoot
    {
        public virtual void Configure(EntityTypeBuilder<TAggregateRoot> builder)
        {
            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.Version)
                .HasConversion(x => x.Value, x => AggregateRootVersion.Restore(x))
                .IsConcurrencyToken();

            ConfigureAggregateRoot(builder);
        }

        public abstract void ConfigureAggregateRoot(EntityTypeBuilder<TAggregateRoot> builder);
    }
}
