using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Application.Requests.SuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IUpdateSuperHeroUseCase
    {
        Task<UpdateSuperHeroCommandResult> Execute(int id, UpdateSuperHeroRequest request);
    }
}
