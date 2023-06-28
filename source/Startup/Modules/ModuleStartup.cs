using BuildingBlocks.Application.Modules;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.Startup.Application;
using BuildingBlocks.Startup.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Startup.Modules
{
    public abstract class ModuleStartup<TModuleSettings, TModule, TDbContext>
            where TModuleSettings : IModuleSettings, new()
            where TModule : Module, new()
            where TDbContext : DbContextBase
    {
        public TModule Initialize(Action<TModuleSettings> action)
        {
            var moduleSettings = new TModuleSettings();

            action(moduleSettings);

            var builder = new ServiceCollection();

            ConfigureContainer(builder, moduleSettings);

            builder.AddApplicationDependencies(moduleSettings.ApplicationLayer);

            builder.AddInfrastructureDependencies<TDbContext>(moduleSettings.InfrastructureLayer, moduleSettings.DbContextOptionsBuilder);

            IServiceProvider container = builder.BuildServiceProvider();

            var module = new TModule();
            
            typeof(Module)
                .GetMethod("SetContainer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(module, new object[] { container });

            return module;
        }

        protected abstract void ConfigureContainer(IServiceCollection builder, TModuleSettings moduleSettings);
    }
}
