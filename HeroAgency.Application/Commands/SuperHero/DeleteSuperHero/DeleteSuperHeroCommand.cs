using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class DeleteSuperHeroCommand : IRequest<DeleteSuperHeroCommandResult>
    {
        public int Id { get; set; }

        public DeleteSuperHeroCommand(int id)
        {
            Id = id;
        }
    }
}
