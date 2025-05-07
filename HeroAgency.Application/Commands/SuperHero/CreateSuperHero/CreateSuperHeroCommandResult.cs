using HeroAgency.Application.Common.Results;
using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Commands.SuperHero.CreateSuperHero
{
    public class CreateSuperHeroCommandResult : CommandResult
    {
        public Domain.Entities.SuperHero Model { get; set; }

        private CreateSuperHeroCommandResult(bool success, string message, ReturnType type, Domain.Entities.SuperHero model = null)
            : base(success, message, type)
        {
            Model = model;
        }

        public static CreateSuperHeroCommandResult Success(Domain.Entities.SuperHero model) =>
            new(true, "Herói criado com sucesso.", ReturnType.Ok, model);

        public static CreateSuperHeroCommandResult NotFound(string message) =>
            new(false, message, ReturnType.NotFound);

        public static CreateSuperHeroCommandResult Conflict(string message) =>
            new(false, message, ReturnType.BadRequest);

        public static CreateSuperHeroCommandResult InternalError(string message) =>
            new(false, message, ReturnType.InternalError);

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
                message = Message
            };
        }
    }
}
