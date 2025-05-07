using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetAllSuperHeroHandler : IRequestHandler<GetAllSuperHeroQuery, GetAllSuperHeroQueryResult>
    {
        private readonly ISuperHeroRepository _repository;
        
        public GetAllSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllSuperHeroQueryResult> Handle(GetAllSuperHeroQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var superHeroes = await _repository.GetAll();

                return GetAllSuperHeroQueryResult.Success(superHeroes);
            } catch(Exception ex)
            {
                return GetAllSuperHeroQueryResult.InternalError($"Ocorreu um erro ao retornar a lista de Super Heróis: {ex.Message}");
            } 
        }
    }
}
