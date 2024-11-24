namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message, 200) { }
        public SuccessResult(string message, int statusCode) : base(true, message, statusCode) { }
        public SuccessResult() : base(true, 200) { }
        public SuccessResult(int statusCode) : base(true, statusCode) { }
    }
}