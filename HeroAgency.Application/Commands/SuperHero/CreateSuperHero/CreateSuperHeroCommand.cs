using HeroAgency.Application.Requests.SuperHero;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class CreateSuperHeroCommand : IRequest<Domain.Entities.SuperHero>
    {
        public CreateSuperHeroRequest Request { get; set; }

        public CreateSuperHeroCommand(CreateSuperHeroRequest request)
        {
            Request = request;
        }
    }
}
