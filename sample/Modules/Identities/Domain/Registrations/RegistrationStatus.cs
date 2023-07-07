using BuildingBlocks.Domain.SystemClocks;
using BuildingBlocks.Domain.ValueObjects;

namespace Identities.Domain.Registrations
{
    public sealed record RegistrationStatus : ValueObject
    {
        public string Value { get; }

        public static RegistrationStatus Pending => new RegistrationStatus(nameof(Pending));

        public static RegistrationStatus Confirmed => new RegistrationStatus(nameof(Confirmed));

        private RegistrationStatus(string value)
        {
            Value = value;
        }
    }
}
