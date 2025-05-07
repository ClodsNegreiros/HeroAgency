using HeroAgency.Domain.Entities;

namespace HeroAgency.Domain.Interfaces
{
    public interface ISuperHeroPowerRepository
    {
        Task<SuperHeroPower> CreateAsync(SuperHeroPower superHeroPower);
        Task<bool> DeleteAsync(SuperHeroPower superHeroPower);
    }
}
