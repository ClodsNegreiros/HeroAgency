using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Domain.Entities;
using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class CreateSuperHeroHandler : IRequestHandler<CreateSuperHeroCommand, CreateSuperHeroCommandResult>
    {
        private readonly ISuperHeroRepository _repository;
        private readonly ISuperHeroPowerRepository _superHeroPowerRepository;

        public CreateSuperHeroHandler(ISuperHeroRepository repository, ISuperHeroPowerRepository superHeroPowerRepository)
        {
            _repository = repository;
            _superHeroPowerRepository = superHeroPowerRepository;
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

                // Cria as associações com os poderes
                await CreateSuperHeroPowersAsync(createdSuperHero.Id, command.Request.SuperHeroPowersIds);

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

        private async Task CreateSuperHeroPowersAsync(int superHeroId, List<int> powerIds)
        {
            if (powerIds == null || !powerIds.Any())
                return;

            foreach (var powerId in powerIds)
            {
                var superHeroPower = new SuperHeroPower
                {
                    SuperHeroId = superHeroId,
                    SuperPowerId = powerId
                };

                await _superHeroPowerRepository.CreateAsync(superHeroPower);
            }
        }
    }
}
