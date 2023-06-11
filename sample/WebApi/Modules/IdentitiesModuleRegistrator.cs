using Identities.Startup;

namespace WebApi.Modules
{
    public static class IdentitiesModuleRegistrator
    {
        internal static IServiceCollection AddIdentitiesModule(this IServiceCollection services)
        {
            var identitiesModule = new IdentitiesStartup().Initialize(x =>
            {});

            return services.AddSingleton(identitiesModule);
        }
    }
}
