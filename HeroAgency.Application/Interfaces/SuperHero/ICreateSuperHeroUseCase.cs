using HeroAgency.Application.Requests.SuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface ICreateSuperHeroUseCase
    {
        Task<Domain.Entities.SuperHero> Execute(CreateSuperHeroRequest request);
    }
}
