using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class DeleteSuperHeroHandler : IRequestHandler<DeleteSuperHeroCommand, DeleteSuperHeroCommandResult>
    {
        private readonly ISuperHeroRepository _repository;

        public DeleteSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteSuperHeroCommandResult> Handle(DeleteSuperHeroCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existingSuperHero = await _repository.GetById(command.Id);
                if (existingSuperHero == null)
                {
                    return DeleteSuperHeroCommandResult.NotFound($"Herói com Id {command.Id} não encontrado.");
                }

                var isSuperHeroDeleted = await _repository.DeleteAsync(existingSuperHero);

                return DeleteSuperHeroCommandResult.Success(existingSuperHero.HeroName);
            }
            catch (Exception ex) 
            {
                return DeleteSuperHeroCommandResult.InternalError($"Erro ao deletar Super Herói: {ex.Message}");
            }
        }
    }
}
