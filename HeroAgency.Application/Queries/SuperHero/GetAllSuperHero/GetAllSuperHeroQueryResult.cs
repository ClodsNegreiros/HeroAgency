using HeroAgency.Application.Common.Results;
using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Commands.SuperHero.CreateSuperHero
{
    public class GetAllSuperHeroQueryResult : QueryResult
    {
        public List<Domain.Entities.SuperHero> Models { get; set; }

        private GetAllSuperHeroQueryResult(bool success, string message, ReturnType type, List<Domain.Entities.SuperHero> models)
            : base(success, message, type)
        {
            Models = models;
        }

        private GetAllSuperHeroQueryResult(bool success, string message, ReturnType type)
            : base(success, message, type)
        {
        }

        public static GetAllSuperHeroQueryResult Success(List<Domain.Entities.SuperHero> models) =>
            new(true, "Super Heróis listados com sucesso.", ReturnType.Ok, models);

        public static GetAllSuperHeroQueryResult InternalError(string message) =>
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
