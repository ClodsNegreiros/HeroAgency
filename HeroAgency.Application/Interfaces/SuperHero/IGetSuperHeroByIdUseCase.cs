
namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IGetSuperHeroByIdUseCase
    {
        Task<Domain.Entities.SuperHero?> Execute(int id);
    }
}
