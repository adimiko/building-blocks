using BuildingBlocks.Startup.Modules;
using Identities.Application;
using Identities.Domain;
using Identities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Identities.Startup
{
    public sealed class IdentitiesSettings : IModuleSettings
    {
        public Assembly DomainLayer => DomainAssembly.Assembly;

        public Assembly ApplicationLayer => ApplicationAssembly.Assembly;

        public Assembly InfrastructureLayer => InfrastructureAssembly.Assembly;

        public Action<DbContextOptionsBuilder> DbContextOptionsBuilder { get; set; }
    }
}
