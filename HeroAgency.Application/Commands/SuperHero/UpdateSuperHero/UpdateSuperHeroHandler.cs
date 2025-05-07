using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class UpdateSuperHeroHandler : IRequestHandler<UpdateSuperHeroCommand, Domain.Entities.SuperHero>
    {
        private readonly ISuperHeroRepository _repository;

        public UpdateSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.SuperHero> Handle(UpdateSuperHeroCommand command, CancellationToken cancellationToken)
        {
            var existingSuperHero = _repository.GetById(command.Id);
            if (existingSuperHero == null)
            {
                throw new KeyNotFoundException($"Herói com Id {command.Id} não encontrado.");
            }

            var superHeroToUpdate = ToUpdate(existingSuperHero.Result!, command);

            return await _repository.UpdateAsync(superHeroToUpdate);
        }


        private Domain.Entities.SuperHero ToUpdate(Domain.Entities.SuperHero superHero, UpdateSuperHeroCommand command)
        {
            superHero.Name = command.Request.Name;
            superHero.HeroName  = command.Request.HeroName;
            superHero.BirthDate = command.Request.BirthDate;
            superHero.Height = command.Request.Height;
            superHero.Weight = command.Request.Weight;

            return superHero;
        }

    }
}
