using HeroAgency.Application.Requests.SuperHero;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class UpdateSuperHeroCommand : IRequest<Domain.Entities.SuperHero>
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
