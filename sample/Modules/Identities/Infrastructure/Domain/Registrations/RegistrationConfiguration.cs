using BuildingBlocks.Domain.AggregateRoots;
using Identities.Domain.Registrations;
using Identities.Domain.SheredKernel.Logins;
using Identities.Domain.SheredKernel.Passwords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identities.Infrastructure.Domain.Registrations
{
    internal class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new RegistrationId(x));

            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.Version)
            .HasConversion(x => x.Value, x => AggregateRootVersion.Restore(x))
            .IsConcurrencyToken();

            //TODO use private constructor with arguments
            builder.Property<Login>("_login")
                .HasConversion(x => x.Value, x => Login.Restore(x));

            builder.Property<Password>("_password").HasConversion(x => x.Value, x => Password.Restore(x));

            builder.OwnsOne<RegistrationStatus>("_status", s =>
            {
                s.Property(x => x.Value);
            });
        }
    }
}
