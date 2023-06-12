﻿using Identities.Domain.Registrations;
using Microsoft.EntityFrameworkCore;

namespace Identities.Infrastructure.Domain.Registrations
{
    internal sealed class RegistrationRepository : IRegistrationRepository
    {
        private readonly DbSet<Registration> _registrations;

        public RegistrationRepository(IdentitiesDbContext context)
        {
            _registrations = context.Registrations;
        }

        public async Task Add(Registration registration)
        {
            await _registrations.AddAsync(registration);
        }

        public async Task<Registration?> Get(RegistrationId id)
        {
            return await _registrations.FindAsync(id);
        }
    }
}
