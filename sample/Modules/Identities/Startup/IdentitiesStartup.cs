using BuildingBlocks.Startup.Modules;
using Identities.Application.Contracts;
using Identities.Application.SeedWorks;
using Identities.Domain.SheredKernel.Logins;
using Identities.Infrastructure;
using Identities.Infrastructure.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Identities.Startup
{
    public sealed class IdentitiesStartup : ModuleStartup<IdentitiesSettings, IdentitiesModule, IdentitiesDbContext>
    {
        protected override void ConfigureContainer(
            IServiceCollection builder,
            IdentitiesSettings moduleSettings)
        {
            builder.AddTransient<IHasher, Hasher>();
            builder.AddTransient<IUniqueLogin, UniqueLogin>();
        }
    }
}
