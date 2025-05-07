using HeroAgency.Application.Common.Results;
using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Commands.SuperHero.CreateSuperHero
{
    public class DeleteSuperHeroCommandResult : CommandResult
    {
        public Domain.Entities.SuperHero Model { get; set; }

        private DeleteSuperHeroCommandResult(bool success, string message, ReturnType type)
            : base(success, message, type)
        {
        }

        public static DeleteSuperHeroCommandResult Success(string heroName) =>
            new(true, $"Herói {heroName} foi deletado com sucesso.", ReturnType.Ok);

        public static DeleteSuperHeroCommandResult NotFound(string message) =>
            new(false, message, ReturnType.NotFound);

        public static DeleteSuperHeroCommandResult Conflict(string message) =>
            new(false, message, ReturnType.BadRequest);

        public static DeleteSuperHeroCommandResult InternalError(string message) =>
            new(false, message, ReturnType.InternalError);

        public dynamic ToJson()
        {
            return new
            {
                IsSuccess,
                Message,
                Type
            };
        }
    }
}
