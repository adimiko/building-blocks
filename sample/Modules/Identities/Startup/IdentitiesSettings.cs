using BuildingBlocks.Startup.Modules;
using Identities.Application;
using Identities.Domain;
using Identities.Infrastructure;
using System.Reflection;

namespace Identities.Startup
{
    public sealed class IdentitiesSettings : IModuleSettings
    {
        public Assembly Domain => DomainAssembly.Assembly;

        public Assembly Application => ApplicationAssembly.Assembly;

        public Assembly Infrastructure => InfrastructureAssembly.Assembly;
    }
}
