using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Application.Requests.SuperHero;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class CreateSuperHeroCommand : IRequest<CreateSuperHeroCommandResult>
    {
        public CreateSuperHeroRequest Request { get; set; }

        public CreateSuperHeroCommand(CreateSuperHeroRequest request)
        {
            Request = request;
        }
    }
}
