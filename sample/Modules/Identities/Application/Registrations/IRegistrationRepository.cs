using Identities.Domain.Registrations;

namespace Identities.Application.Registrations
{
    public interface IRegistrationRepository
    {
        Task Add(Registration registration);
    }
}
