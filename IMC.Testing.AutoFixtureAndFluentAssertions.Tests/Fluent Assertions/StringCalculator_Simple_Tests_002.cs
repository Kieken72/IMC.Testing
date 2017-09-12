using FluentAssertions;
using Xunit;

namespace IMC.Testing.AutoFixtureAndFluentAssertions.Tests
{
    public class StringCalculator_Simple_Tests_002
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Simple_Tests_002()
        {
            _calulator = new StringCalulator();
        }

        [Fact]
        public void Add_With_Fifteen_Numbers_Returns_Number()
        {
            //Setup

            //Act
            var number = _calulator.Add("5,5,5,5,5,5,5,5,5,5,5,5,5,5,5");

            //Assert
            number.Should().Be(75);
        }
    }
}
