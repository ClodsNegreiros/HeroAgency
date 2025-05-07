using HeroAgency.Domain.Entities;
using HeroAgency.Domain.Interfaces;
using HeroAgency.Infrastructure.Context;

namespace HeroAgency.Infrastructure.Repositories
{
    public class SuperHeroPowerRepository : ISuperHeroPowerRepository
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroPowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SuperHeroPower> CreateAsync(SuperHeroPower superHeroPower)
        {
            await _context.SuperHeroPowers.AddAsync(superHeroPower);
            await _context.SaveChangesAsync();

            return superHeroPower;
        }

        public async Task<bool> DeleteAsync(SuperHeroPower superHeroPower)
        {
            _context.SuperHeroPowers.Remove(superHeroPower);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
