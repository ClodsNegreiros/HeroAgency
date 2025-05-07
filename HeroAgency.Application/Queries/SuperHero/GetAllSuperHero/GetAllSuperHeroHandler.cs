using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetAllSuperHeroHandler : IRequestHandler<GetAllSuperHeroQuery, List<Domain.Entities.SuperHero>>
    {
        private readonly ISuperHeroRepository _repository;
        
        public GetAllSuperHeroHandler(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.SuperHero>> Handle(GetAllSuperHeroQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
