using BuildingBlocks.Domain.SystemClocks;
using BuildingBlocks.Domain.ValueObjects;

namespace Identities.Domain.Registrations
{
    public sealed record RegistrationStatus : ValueObject
    {
        private static TimeSpan _validityPeriod => TimeSpan.FromHours(1);

        public string Value { get; }

        public DateTime ExpirationDate { get; }

        public static RegistrationStatus Pending => new RegistrationStatus(nameof(Pending), SystemClock.UtcNow + _validityPeriod);

        public RegistrationStatus Confirmed => new RegistrationStatus(nameof(Confirmed), ExpirationDate);

        private RegistrationStatus(string value, DateTime expirationDate)
        {
            Value = value;
            ExpirationDate = expirationDate;
        }
    }
}
