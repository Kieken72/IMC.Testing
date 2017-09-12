using FluentAssertions;
using Xunit;

namespace IMC.Testing.AutoFixtureAndFluentAssertions.Tests
{
    public class StringCalculator_Simple_Tests_004
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Simple_Tests_004()
        {
            _calulator = new StringCalulator();
        }
        [Fact]
        public void Add_With_Two_Numbers_Returns_Number_Different_Delimiter()
        {
            //Setup

            //Act
            var number = _calulator.Add("\\\\*\\n5*5");

            //Assert
            number.Should().Be(10);
        }

        [Fact]
        public void Add_With_Three_Numbers_Returns_Number_Different_Delimiter()
        {
            //Setup

            //Act
            var number = _calulator.Add("\\\\a\\n5a5a5");

            //Assert
            number.Should().Be(15);
        }
    }
}
