using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Infrastructure.AggregateRoots;
using Identities.Domain.Registrations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identities.Infrastructure.Domain.Registrations
{
    internal class RegistrationConfiguration : AggregateRootConfiguration<Registration>
    {
        public override void ConfigureAggregateRoot(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new RegistrationId(x));

            builder.Property(x => x.Version)
            .HasConversion(x => x.Value, x => AggregateRootVersion.Restore(x))
            .IsConcurrencyToken();

            //TODO use private constructor with arguments
            builder.Property<RegistrationLogin>("_login")
                .HasConversion(x => x.Value, x => RegistrationLogin.Restore(x));

            builder.Property<RegistrationPassword>("_password").HasConversion(x => x.Value, x => RegistrationPassword.Restore(x));

            builder.OwnsOne<RegistrationStatus>("_status", s =>
            {
                s.Property(x => x.Value);
            });
        }
    }
}
