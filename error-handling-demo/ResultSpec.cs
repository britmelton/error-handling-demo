using error_handling_demo.Domain;
using FluentAssertions;

namespace error_handling_demo
{
    public class ResultSpec
    {
        public class WhenInstantiatingASuccess
        {
            [Fact]
            public void ThenIsSuccessIsTrue()
            {
                var result = Result.Success();

                result.IsSuccess.Should().BeTrue();
            }

            [Fact]
            public void ThenIsFailureIsFalse()
            {
                var result = Result.Success();

                result.IsFailure.Should().BeFalse();
            }

            [Fact]
            public void ThenErrorIsNull()
            {
                var result = Result.Success();

                result.Error.Should().BeNull();
            }
        }

        public class WhenInstantiatingAFailure
        {
            public static IEnumerable<object[]> GetErrors()
            {
                yield return new[] { Error.InvalidOperation() };
                yield return new[] { Error.ArgumentNull() };

            }

            [Fact]
            public void ThenIsSuccessIsFalse()
            {
                var result = Result.Failure(Error.InvalidOperation());

                result.IsSuccess.Should().BeFalse();
            }

            [Fact]
            public void ThenIsFailureIsTrue()
            {
                var result = Result.Failure(Error.ArgumentNull());

                result.IsFailure.Should().BeTrue();

            }

            [Theory]
            [MemberData(nameof(GetErrors))]
            public void ThenErrorIsExpected(Error error)
            {
                var result = Result.Failure(error);

                result.Error.Should().Be(error);

            }
        }
    }
}