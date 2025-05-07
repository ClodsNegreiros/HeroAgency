using HeroAgency.Application.Requests.SuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IDeleteSuperHeroUseCase
    {
        Task<bool> Execute(int id);
    }
}
