using System.Reflection;

namespace Identities.Infrastructure
{
    public static class InfrastructureAssembly
    {
        public static Assembly Assembly => Assembly.GetExecutingAssembly();
    }
}
