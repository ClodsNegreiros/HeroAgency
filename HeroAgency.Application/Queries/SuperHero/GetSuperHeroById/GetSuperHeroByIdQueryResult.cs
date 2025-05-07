using HeroAgency.Application.Common.Results;
using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Commands.SuperHero.CreateSuperHero
{
    public class GetSuperHeroByIdQueryResult : QueryResult
    {
        public Domain.Entities.SuperHero Model { get; set; }

        private GetSuperHeroByIdQueryResult(bool success, string message, ReturnType type, Domain.Entities.SuperHero model = null)
            : base(success, message, type)
        {
            Model = model;
        }

        public static GetSuperHeroByIdQueryResult Success(Domain.Entities.SuperHero model) =>
            new(true, "Super Heróis listados com sucesso.", ReturnType.Ok, model);

        public static GetSuperHeroByIdQueryResult InternalError(string message) =>
            new(false, message, ReturnType.InternalError);

        public static GetSuperHeroByIdQueryResult NotFound(string message) =>
            new(false, message, ReturnType.NotFound);

        public dynamic ToJson()
        {
            if (IsSuccess && Model != null)
            {
                return new
                {
                    IsSuccess,
                    Message,
                    Type,
                    Model
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
