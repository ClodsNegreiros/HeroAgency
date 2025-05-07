using HeroAgency.Application.Requests.SuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IUpdateSuperHeroUseCase
    {
        Task<Domain.Entities.SuperHero> Execute(int id, UpdateSuperHeroRequest request);
    }
}
