using System.Reflection;

namespace BuildingBlocks.Startup.Modules
{
    public interface IModuleSettings
    {
        Assembly Domain { get; }

        Assembly Application { get; }

        Assembly Infrastructure { get; }
    }
}
