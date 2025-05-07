using HeroAgency.Domain.Entities;
using HeroAgency.Domain.Interfaces;
using HeroAgency.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HeroAgency.Infrastructure.Repositories
{
    public class SuperPowerRepository : ISuperPowerRepository
    {
        private readonly ApplicationDbContext _context;

        public SuperPowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<SuperPower>> GetAll()
        {
            return await _context.SuperPowers.ToListAsync();
        }
    }
}
