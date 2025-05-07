using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetSuperHeroByIdHandler : IRequestHandler<GetSuperHeroByIdQuery, Domain.Entities.SuperHero?>
    {
        private readonly ISuperHeroRepository _repository;
        
        public GetSuperHeroByIdHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.SuperHero?> Handle(GetSuperHeroByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetById(query.Id);
        }
    }
}
