namespace error_handling_demo.Domain
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error? Error { get; }

        private Result(bool isSuccess, Error? error = default)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }
    }
}
