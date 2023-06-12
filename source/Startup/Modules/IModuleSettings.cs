using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BuildingBlocks.Startup.Modules
{
    public interface IModuleSettings
    {
        Assembly DomainLayer { get; }

        Assembly ApplicationLayer { get; }

        Assembly InfrastructureLayer { get; }

        Action<DbContextOptionsBuilder> DbContextOptionsBuilder { get; set; }
    }
}
