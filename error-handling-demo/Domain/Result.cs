namespace error_handling_demo.Domain
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error? Error { get; }

        protected Result()
        { }

        private Result(bool isSuccess, Error? error = default)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }
    }
    public class Result<T> : Result
    {
        public T Value { get; }

        public Result(T value)
        {
            Value = value;
        }
    }
}
