using HeroAgency.Domain.Entities;
using HeroAgency.Domain.Interfaces;
using HeroAgency.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HeroAgency.Infrastructure.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SuperHero> CreateAsync(SuperHero superHero)
        {
            await _context.SuperHeroes.AddAsync(superHero);
            await _context.SaveChangesAsync();

            return superHero;
        }

        public async Task<SuperHero> UpdateAsync(SuperHero superHero)
        {
            _context.SuperHeroes.Update(superHero);
            await _context.SaveChangesAsync();

            return superHero;
        }

        public async Task<SuperHero?> GetById(int id)
        {
            return await _context.SuperHeroes
                .Where(sh => sh.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<List<SuperHero>> GetAll()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<bool> DeleteAsync(SuperHero superHero)
        {
            _context.SuperHeroes.Remove(superHero);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SuperHero?> GetByHeroName(string heroName)
        {
            return await _context.SuperHeroes
                .SingleOrDefaultAsync(sh => EF.Functions.ILike(sh.HeroName, heroName));
        }
    }
}
