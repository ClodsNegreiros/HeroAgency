using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Common.Results
{
    public class CommandResult
    {
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ReturnType Type { get; private set; }

        protected CommandResult(bool isSuccess, string message, ReturnType type)
        {
            IsSuccess = isSuccess;
            Message = message;
            Type = type;
        }

        protected CommandResult(bool isSuccess, List<string> errors, ReturnType type)
        {
            IsSuccess = isSuccess;
            Errors = errors;
            Type = type;
        }

        public static CommandResult Result(bool isSuccess, string message, ReturnType type) =>
            new CommandResult(isSuccess, message, type);

        public static CommandResult Result(bool isSuccess, List<string> errors, ReturnType type) =>
            new CommandResult(isSuccess, errors, type);
    }
}
