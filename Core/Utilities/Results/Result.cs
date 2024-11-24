namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public int StatusCode { get; }

        public Result(bool success, string message, int statusCode) : this(success, message)
        {
            StatusCode = statusCode;
        }
        public Result(bool success, int statusCode) : this(success)
        {
            StatusCode = statusCode;
        }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        
    }
}