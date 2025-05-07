namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IGetAllSuperHeroUseCase
    {
        Task<List<Domain.Entities.SuperHero>> Execute();
    }
}
