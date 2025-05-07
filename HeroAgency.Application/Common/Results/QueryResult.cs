using HeroAgency.Domain.Enums;

namespace HeroAgency.Application.Common.Results
{
    public class QueryResult
    {
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ReturnType Type { get; private set; }

        protected QueryResult(bool isSuccess, string message, ReturnType type)
        {
            IsSuccess = isSuccess;
            Message = message;
            Type = type;
        }

        protected QueryResult(bool isSuccess, List<string> errors, ReturnType type)
        {
            IsSuccess = isSuccess;
            Errors = errors;
            Type = type;
        }

        public static QueryResult Result(bool isSuccess, string message, ReturnType type) =>
            new QueryResult(isSuccess, message, type);

        public static QueryResult Result(bool isSuccess, List<string> errors, ReturnType type) =>
            new QueryResult(isSuccess, errors, type);
    }
}
