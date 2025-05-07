using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetSuperHeroByIdQuery : IRequest<GetSuperHeroByIdQueryResult>
    {
        public int Id { get; set; }
        public GetSuperHeroByIdQuery(int id)
        {
            Id = id;
        }
    }
}
