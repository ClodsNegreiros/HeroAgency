using HeroAgency.Application.Common.Results;
using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Commands.SuperHero.CreateSuperHero
{
    public class UpdateSuperHeroCommandResult : CommandResult
    {
        public Domain.Entities.SuperHero Model { get; set; }

        private UpdateSuperHeroCommandResult(bool success, string message, ReturnType type, Domain.Entities.SuperHero model = null)
            : base(success, message, type)
        {
            Model = model;
        }

        public static UpdateSuperHeroCommandResult Success(Domain.Entities.SuperHero model) =>
            new(true, "Herói atualizado com sucesso.", ReturnType.Ok, model);

        public static UpdateSuperHeroCommandResult NotFound(string message) =>
            new(false, message, ReturnType.NotFound);

        public static UpdateSuperHeroCommandResult Conflict(string message) =>
            new(false, message, ReturnType.BadRequest);

        public static UpdateSuperHeroCommandResult InternalError(string message) =>
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
