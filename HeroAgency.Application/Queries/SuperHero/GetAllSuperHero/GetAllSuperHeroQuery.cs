using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetAllSuperHeroQuery : IRequest<List<Domain.Entities.SuperHero>>
    {
    }
}
