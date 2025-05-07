using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetSuperHeroByIdHandler : IRequestHandler<GetSuperHeroByIdQuery, GetSuperHeroByIdQueryResult>
    {
        private readonly ISuperHeroRepository _repository;
        
        public GetSuperHeroByIdHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSuperHeroByIdQueryResult> Handle(GetSuperHeroByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var existingSuperHero = await _repository.GetById(query.Id);
                if (existingSuperHero == null)
                {
                    return GetSuperHeroByIdQueryResult.NotFound($"Herói com Id {query.Id} não encontrado.");
                }

                return GetSuperHeroByIdQueryResult.Success(existingSuperHero);
            }
            catch (Exception ex) 
            {
                return GetSuperHeroByIdQueryResult.InternalError($"Ocorreu um erro ao tentar buscar o Super Herói: {ex.Message}");
            }    
        }
    }
}
