using HeroAgency.Domain.Interfaces;
using MediatR;
using System.Data;

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
            var existingSuperHero = await _repository.GetById(command.Id);
            if (existingSuperHero == null)
            {
                throw new KeyNotFoundException($"Herói com Id {command.Id} não encontrado.");
            }

            var existingHeroWithHeroName = await _repository.GetByHeroName(command.Request.HeroName);

            if (existingHeroWithHeroName != null)
            {
                throw new DuplicateNameException($"Herói com nome de Herói {command.Request.HeroName} já cadastrado. Tente novamente com outro.");
            }

            var superHeroToUpdate = ToUpdate(existingSuperHero, command);

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
