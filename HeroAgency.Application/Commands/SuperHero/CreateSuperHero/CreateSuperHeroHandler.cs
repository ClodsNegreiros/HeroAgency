using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class CreateSuperHeroHandler : IRequestHandler<CreateSuperHeroCommand, Domain.Entities.SuperHero>
    {
        private readonly ISuperHeroRepository _repository;

        public CreateSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.SuperHero> Handle(CreateSuperHeroCommand command, CancellationToken cancellationToken)
        {
            var superHero = ToModel(command);
         
            return await _repository.CreateAsync(superHero);
        }

        private Domain.Entities.SuperHero ToModel(CreateSuperHeroCommand command)
        {
            return new Domain.Entities.SuperHero(command.Request.Name, command.Request.HeroName, command.Request.BirthDate, command.Request.Height, command.Request.Weight);
        }
    }
}
