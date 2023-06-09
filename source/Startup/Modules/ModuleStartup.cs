using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Startup.Modules
{
    public abstract class ModuleStartup<TModuleSettings, TModule>
            where TModuleSettings : IModuleSettings, new()
            where TModule : Application.Modules.Module, new()
    {
        public TModule Initialize(Action<TModuleSettings> action)
        {
            var moduleSettings = new TModuleSettings();

            action(moduleSettings);

            var builder = ConfigureContainer(new ServiceCollection(), moduleSettings);

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
