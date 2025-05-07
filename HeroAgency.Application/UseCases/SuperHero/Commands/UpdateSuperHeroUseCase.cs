using HeroAgency.Application.Commands.SuperHero.CreateHero;
using HeroAgency.Application.Interfaces.SuperHero;
using HeroAgency.Application.Requests.SuperHero;
using MediatR;

namespace HeroAgency.Application.UseCases.SuperHero.Commands
{
    public class UpdateSuperHeroUseCase : BaseUseCase, IUpdateSuperHeroUseCase
    {
        public UpdateSuperHeroUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<Domain.Entities.SuperHero> Execute(int id, UpdateSuperHeroRequest request)
        {
            return await mediator.Send(new UpdateSuperHeroCommand(id, request));
        }
    }
}
