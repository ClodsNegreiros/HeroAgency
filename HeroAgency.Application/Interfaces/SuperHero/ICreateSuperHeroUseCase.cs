using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Application.Requests.SuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface ICreateSuperHeroUseCase
    {
        Task<CreateSuperHeroCommandResult> Execute(CreateSuperHeroRequest request);
    }
}
