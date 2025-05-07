using HeroAgency.Application.Commands.SuperHero.CreateHero;
using HeroAgency.Application.Interfaces.SuperHero;
using MediatR;

namespace HeroAgency.Application.UseCases.SuperHero.Commands
{
    public class DeleteSuperHeroUseCase : BaseUseCase, IDeleteSuperHeroUseCase
    {
        public DeleteSuperHeroUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(int id)
        {
            return await mediator.Send(new DeleteSuperHeroCommand(id));
        }
    }
}
