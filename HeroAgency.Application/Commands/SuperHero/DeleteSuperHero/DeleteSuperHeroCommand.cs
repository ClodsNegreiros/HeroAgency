using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class DeleteSuperHeroCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteSuperHeroCommand(int id)
        {
            Id = id;
        }
    }
}
