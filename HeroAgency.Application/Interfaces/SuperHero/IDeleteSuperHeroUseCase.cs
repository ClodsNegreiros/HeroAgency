using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IDeleteSuperHeroUseCase
    {
        Task<DeleteSuperHeroCommandResult> Execute(int id);
    }
}
