using error_handling_demo.Domain;
using FluentAssertions;

namespace error_handling_demo
{
    public class ErrorSpec
    {
        public class WhenInstantiating
        {
            [Fact]
            public void ThenTheCodeIsSet()
            {
                var error = Error.InvalidOperation();
                error.Code.Should().Be("Error.InvalidOperation");
            }

            [Theory]
            [InlineData(null)]
            [InlineData("this is an invalid operation")]
            public void ThenDebugInfoIsExpected(string debugInfo)
            {
                var error = Error.InvalidOperation(debugInfo);
                error.DebugInfo.Should().Be(debugInfo);
            }
        }

        public class WhenEvaluatingEquality : ValueObjectSpec.WhenEvaluatingEquality
        {
            public override ValueObject Create()
            {
                var error = Error.InvalidOperation();
                return error;
            }

            public override ValueObject CreateOther()
            {
                var error = Error.ArgumentNull();
                return error;
            }

            [Fact]
            public void WithSameCodeButDifferentDebugInfo_ThenReturnTrue()
            {
                var error = Error.InvalidOperation("cannot sell inactive product");
                var otherError = Error.InvalidOperation("cannot delete active product");

                error.Should().Be(otherError);
            }
        }
    }
}
