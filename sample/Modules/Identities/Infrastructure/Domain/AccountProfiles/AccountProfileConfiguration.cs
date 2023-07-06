using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.AccountProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identities.Infrastructure.Domain.AccountProfiles
{
    internal sealed class AccountProfileConfiguration : IEntityTypeConfiguration<AccountProfile>
    {
        public void Configure(EntityTypeBuilder<AccountProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AccountProfileId(x));

            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.Version)
            .HasConversion(x => x.Value, x => AggregateRootVersion.Restore(x))
            .IsConcurrencyToken();

            builder.Property<Nick>("_nick")
                .HasConversion(x => x.Value, x => Nick.Restore(x));
        }
    }
}
