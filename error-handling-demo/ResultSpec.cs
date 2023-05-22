using error_handling_demo.Domain;
using FluentAssertions;

namespace error_handling_demo
{
    public class ResultSpec
    {
        public class WhenInstantiatingASuccess
        {
            private readonly Result _result;

            public WhenInstantiatingASuccess()
            {
                _result = Result.Success();
            }

            [Fact]
            public void ThenIsSuccessIsTrue()
            {
                _result.IsSuccess.Should().BeTrue();
            }

            [Fact]
            public void ThenIsFailureIsFalse()
            {
                _result.IsFailure.Should().BeFalse();
            }

            [Fact]
            public void ThenErrorIsNull()
            {
                _result.Error.Should().BeNull();
            }

            public class WithAValue : WhenInstantiatingASuccess
            {
                [Fact]
                public void ThenValueIsExpected()
                {
                    var id = Guid.NewGuid();
                    var result = Result.Success(id);

                    result.Value.Should().Be(id);
                }
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