namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message, 200) { }

        public SuccessDataResult(T data) : base(data, true, 200) { }

        public SuccessDataResult(string message) : base(default, true, message, 200) { }

        public SuccessDataResult() : base(default, true, 200) { }

        public SuccessDataResult(int statusCode) : base(default, true, statusCode) { }
    }
}