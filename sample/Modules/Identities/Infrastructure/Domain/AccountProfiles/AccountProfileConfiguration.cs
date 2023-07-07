using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Infrastructure.AggregateRoots;
using Identities.Domain.AccountProfiles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identities.Infrastructure.Domain.AccountProfiles
{
    internal sealed class AccountProfileConfiguration : AggregateRootConfiguration<AccountProfile>
    {
        public override void ConfigureAggregateRoot(EntityTypeBuilder<AccountProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AccountProfileId(x));

            builder.Property(x => x.Version)
            .HasConversion(x => x.Value, x => AggregateRootVersion.Restore(x))
            .IsConcurrencyToken();

            builder.Property<Nick>("_nick")
                .HasConversion(x => x.Value, x => Nick.Restore(x));
        }
    }
}
