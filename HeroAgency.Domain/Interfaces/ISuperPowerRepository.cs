using HeroAgency.Domain.Entities;

namespace HeroAgency.Domain.Interfaces
{
    public interface ISuperPowerRepository
    {
        Task<List<SuperPower>> GetAll();
    }
}
