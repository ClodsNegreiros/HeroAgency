using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Commands.SuperHero.CreateHero
{
    public class DeleteSuperHeroHandler : IRequestHandler<DeleteSuperHeroCommand, bool>
    {
        private readonly ISuperHeroRepository _repository;

        public DeleteSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteSuperHeroCommand command, CancellationToken cancellationToken)
        {
            var existingSuperHero = await _repository.GetById(command.Id);
            if (existingSuperHero == null)
            {
                throw new KeyNotFoundException($"Herói com Id {command.Id} não encontrado.");
            }

            return await _repository.DeleteAsync(existingSuperHero);
        }
    }
}
