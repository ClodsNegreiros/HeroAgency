using HeroAgency.Domain.Entities;

namespace HeroAgency.Domain.Interfaces
{
    public interface ISuperHeroRepository
    {
        Task<SuperHero> CreateAsync(SuperHero superHero);
        Task<bool> DeleteAsync(SuperHero superHero);
        Task<List<SuperHero>> GetAll();
        Task<SuperHero?> GetById(int id);
        Task<SuperHero> UpdateAsync(SuperHero superHero);
    }
}
