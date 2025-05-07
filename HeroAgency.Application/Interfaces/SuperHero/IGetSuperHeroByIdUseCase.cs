
using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IGetSuperHeroByIdUseCase
    {
        Task<GetSuperHeroByIdQueryResult> Execute(int id);
    }
}
