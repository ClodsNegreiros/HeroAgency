using HeroAgency.Application.Commands.SuperHero.CreateHero;
using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Application.Interfaces.SuperHero;
using HeroAgency.Application.Requests.SuperHero;
using MediatR;

namespace HeroAgency.Application.UseCases.SuperHero.Commands
{
    public class CreateSuperHeroUseCase : BaseUseCase, ICreateSuperHeroUseCase
    {
        public CreateSuperHeroUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<CreateSuperHeroCommandResult> Execute(CreateSuperHeroRequest request)
        {
            return await mediator.Send(new CreateSuperHeroCommand(request));
        }
    }
}
