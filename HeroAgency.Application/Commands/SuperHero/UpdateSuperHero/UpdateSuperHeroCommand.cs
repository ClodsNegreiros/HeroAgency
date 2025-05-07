using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Application.Requests.SuperHero;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class UpdateSuperHeroCommand : IRequest<UpdateSuperHeroCommandResult>
    {
        public int Id { get; set; }
        public UpdateSuperHeroRequest Request { get; set; }

        public UpdateSuperHeroCommand(int id, UpdateSuperHeroRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
