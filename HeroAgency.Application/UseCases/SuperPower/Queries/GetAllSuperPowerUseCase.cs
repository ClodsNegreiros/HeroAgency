using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Application.Interfaces.SuperHero;
using HeroAgency.Application.Queries.SuperHero.GetAllSuperHero;
using MediatR;

namespace HeroAgency.Application.UseCases.SuperHero.Queries
{
    public class GetAllSuperPowerUseCase : BaseUseCase, IGetAllSuperPowerUseCase
    {
        public GetAllSuperPowerUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<GetAllSuperPowerQueryResult> Execute()
        {
            return await mediator.Send(new GetAllSuperPowerQuery());
        }
    }
}
