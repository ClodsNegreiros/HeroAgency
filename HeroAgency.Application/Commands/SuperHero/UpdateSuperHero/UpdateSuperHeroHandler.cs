using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class UpdateSuperHeroHandler : IRequestHandler<UpdateSuperHeroCommand, UpdateSuperHeroCommandResult>
    {
        private readonly ISuperHeroRepository _repository;

        public UpdateSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateSuperHeroCommandResult> Handle(UpdateSuperHeroCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existingSuperHero = await _repository.GetById(command.Id);
                if (existingSuperHero == null)
                {
                    return UpdateSuperHeroCommandResult.NotFound($"Herói com Id {command.Id} não encontrado.");
                }

                var existingHeroWithHeroName = await _repository.GetByHeroName(command.Request.HeroName);

                if (existingHeroWithHeroName != null)
                {
                    return UpdateSuperHeroCommandResult.Conflict($"Herói com nome de Herói {command.Request.HeroName} já cadastrado. Tente novamente com outro.");
                }

                var superHeroToUpdate = ToUpdate(existingSuperHero!, command);
                var updatedSuperHero = await _repository.UpdateAsync(superHeroToUpdate);

                return UpdateSuperHeroCommandResult.Success(updatedSuperHero);
            } catch(Exception ex)
            {
                return UpdateSuperHeroCommandResult.InternalError($"Ocorreu um erro ao atualizar Herói: {ex.Message}");
            }
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
