using HeroAgency.Application.Common.Results;
using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Commands.SuperHero.CreateSuperHero
{
    public class GetAllSuperPowerQueryResult : QueryResult
    {
        public List<Domain.Entities.SuperPower> Models { get; set; }

        private GetAllSuperPowerQueryResult(bool success, string message, ReturnType type, List<Domain.Entities.SuperPower> models)
            : base(success, message, type)
        {
            Models = models;
        }

        private GetAllSuperPowerQueryResult(bool success, string message, ReturnType type)
            : base(success, message, type)
        {
        }

        public static GetAllSuperPowerQueryResult Success(List<Domain.Entities.SuperPower> models) =>
            new(true, "Super Poderes listados com sucesso.", ReturnType.Ok, models);

        public static GetAllSuperPowerQueryResult InternalError(string message) =>
            new(false, message, ReturnType.InternalError);

        public dynamic ToJson()
        {
            if (IsSuccess && Models != null)
            {
                return new
                {
                    IsSuccess,
                    Message,
                    Type,
                    Models = Models?.Select(model => model)
                };
            }

            return new
            {
                IsSuccess,
                Message,
                Type
            };
        }
    }
}
