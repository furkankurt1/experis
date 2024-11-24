namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message) { }
        public ErrorDataResult(T data, string message, int statusCode) : base(data, false, message, statusCode) { }
        public ErrorDataResult(T data) : base(data, false) { }
        public ErrorDataResult(T data,int statusCode) : base(data, false,statusCode) { }
        public ErrorDataResult(string message) : base(default, false, message,400) { }
        public ErrorDataResult(int statusCode) : base(default, false, statusCode) { }
        public ErrorDataResult(string message, int statusCode) : base(default, false, message,statusCode) { }
        public ErrorDataResult() : base(default, false,400) { }
        
    }
}