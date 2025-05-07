using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IGetAllSuperHeroUseCase
    {
        Task<GetAllSuperHeroQueryResult> Execute();
    }
}
