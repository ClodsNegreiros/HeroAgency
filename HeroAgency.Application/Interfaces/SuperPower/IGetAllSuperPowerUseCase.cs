
using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;

namespace HeroAgency.Application.Interfaces.SuperHero
{
    public interface IGetAllSuperPowerUseCase
    {
        Task<GetAllSuperPowerQueryResult> Execute();
    }
}
