using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetAllSuperHeroQuery : IRequest<GetAllSuperHeroQueryResult>
    {
    }
}
