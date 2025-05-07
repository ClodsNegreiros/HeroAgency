using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Domain.Interfaces;
using MediatR;

namespace HeroAgency.Application.Queries.SuperHero.GetAllSuperHero
{
    public class GetAllSuperPowerHandler : IRequestHandler<GetAllSuperPowerQuery, GetAllSuperPowerQueryResult>
    {
        private readonly ISuperPowerRepository _repository;
        
        public GetAllSuperPowerHandler(ISuperPowerRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllSuperPowerQueryResult> Handle(GetAllSuperPowerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var superPowers = await _repository.GetAll();

                return GetAllSuperPowerQueryResult.Success(superPowers);
            } catch(Exception ex)
            {
                return GetAllSuperPowerQueryResult.InternalError($"Ocorreu um erro ao retornar a lista de Super Poderes: {ex.Message}");
            } 
        }
    }
}
