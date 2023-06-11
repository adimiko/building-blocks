using BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Startup.Modules
{
    public abstract class ModuleStartup<TModuleSettings, TModule, TDbContext>
            where TModuleSettings : IModuleSettings, new()
            where TModule : Application.Modules.Module, new()
            where TDbContext : DbContextBase
    {
        public TModule Initialize(Action<TModuleSettings> action)
        {
            var moduleSettings = new TModuleSettings();

            action(moduleSettings);

            var builder = ConfigureContainer(new ServiceCollection(), moduleSettings);

            builder.AddDbContextPool<TDbContext>(options => options.UseInMemoryDatabase("123"));
            builder.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<TDbContext>()));


            //TODO
            builder.AddMediatR(config => config.RegisterServicesFromAssembly(moduleSettings.Application));

            builder.Scan(scan => scan
              .FromAssemblies(moduleSettings.Infrastructure)
              .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
              .AsImplementedInterfaces()
              .WithTransientLifetime());

            IServiceProvider container = builder.BuildServiceProvider();

            var module = new TModule();
            
            typeof(Application.Modules.Module)
                .GetMethod("SetContainer", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.Invoke(module, new object[] { container });

            return module;
        }

        protected abstract IServiceCollection ConfigureContainer(IServiceCollection builder, TModuleSettings moduleSettings);
    }
}
