using Identities.Startup;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Modules
{
    public static class IdentitiesModuleRegistrator
    {
        internal static IServiceCollection AddIdentitiesModule(this IServiceCollection services)
        {
            var identitiesModule = new IdentitiesStartup().Initialize(x =>
            {
                x.DbContextOptionsBuilder = x => x.UseInMemoryDatabase("123");
            });

            return services.AddSingleton(identitiesModule);
        }
    }
}
