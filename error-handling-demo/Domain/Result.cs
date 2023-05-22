namespace error_handling_demo.Domain
{
    public class Result
    {
        public bool IsSuccess => Error is null;
        public bool IsFailure => !IsSuccess;
        public Error? Error { get; }

        protected Result(Error? error = default)
        {
            Error = error;
        }

        public static Result Success()
        {
            return new();
        }

        public static Result<T> Success<T>(T value)
        {
            return new(value);
        }

        public static Result Failure(Error error)
        {
            return new(error);
        }

        public static implicit operator Result(Error error) => new(error);
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        public Result(Error error) : base(error)
        { }

        public Result(T value)
        {
            Value = value;
        }

        public static implicit operator Result<T>(T value) => new(value);
        public static implicit operator Result<T>(Error error) => new(error);
    }
}
