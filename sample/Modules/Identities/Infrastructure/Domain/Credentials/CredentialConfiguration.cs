using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Credentials;
using Identities.Domain.Registrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identities.Infrastructure.Domain.Credentials
{
    internal sealed class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new CredentialId(x));

            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.Version)
            .HasConversion(x => x.Value, x => AggregateRootVersion.Restore(x))
            .IsConcurrencyToken();

            builder.Property<RegistrationLogin>("_login")
                .HasConversion(x => x.Value, x => RegistrationLogin.Restore(x));

            builder.Property<RegistrationPassword>("_password")
                .HasConversion(x => x.Value, x => RegistrationPassword.Restore(x));
        }
    }
}
