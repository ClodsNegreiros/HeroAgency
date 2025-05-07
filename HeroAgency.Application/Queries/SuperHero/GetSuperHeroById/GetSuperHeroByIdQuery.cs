using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetSuperHeroByIdQuery : IRequest<Domain.Entities.SuperHero?>
    {
        public int Id { get; set; }
        public GetSuperHeroByIdQuery(int id)
        {
            Id = id;
        }
    }
}
