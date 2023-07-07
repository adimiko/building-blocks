using System.Reflection;

namespace Identities.Domain
{
    public static class DomainAssembly
    {
        public static Assembly Assembly => Assembly.GetExecutingAssembly();
    }
}
