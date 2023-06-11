namespace Identities.Domain.Registrations
{
    public interface IRegistrationRepository
    {
        Task<Registration?> Get(RegistrationId id);

        Task Add(Registration registration);
    }
}
