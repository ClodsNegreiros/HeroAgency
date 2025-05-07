using HeroAgency.Application.Interfaces.SuperHero;
using HeroAgency.Application.Queries.SuperHero.GetAllSuperHero;
using MediatR;

namespace HeroAgency.Application.UseCases.SuperHero.Queries
{
    public class GetSuperHeroByIdUseCase : BaseUseCase, IGetSuperHeroByIdUseCase
    {
        public GetSuperHeroByIdUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<Domain.Entities.SuperHero?> Execute(int id)
        {
            return await mediator.Send(new GetSuperHeroByIdQuery(id));
        }
    }
}
