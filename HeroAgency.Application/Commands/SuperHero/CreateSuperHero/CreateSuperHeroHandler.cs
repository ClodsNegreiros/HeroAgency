using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class CreateSuperHeroHandler : IRequestHandler<CreateSuperHeroCommand, CreateSuperHeroCommandResult>
    {
        private readonly ISuperHeroRepository _repository;

        public CreateSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateSuperHeroCommandResult> Handle(CreateSuperHeroCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existingHeroWithHeroName = await _repository.GetByHeroName(command.Request.HeroName);

                if (existingHeroWithHeroName != null)
                {
                    return CreateSuperHeroCommandResult.Conflict($"Herói com nome de Herói {command.Request.HeroName} já cadastrado. Tente novamente com outro.");
                }

                var superHero = ToModel(command);
                var createdSuperHero = await _repository.CreateAsync(superHero);

                return CreateSuperHeroCommandResult.Success(createdSuperHero);
            }
            catch (Exception ex) 
            {
                return CreateSuperHeroCommandResult.InternalError($"Erro ao cadastrar Herói: {ex.Message}");
            }
        }

        private Domain.Entities.SuperHero ToModel(CreateSuperHeroCommand command)
        {
            return new Domain.Entities.SuperHero(command.Request.Name, command.Request.HeroName, command.Request.BirthDate, command.Request.Height, command.Request.Weight);
        }
    }
}
