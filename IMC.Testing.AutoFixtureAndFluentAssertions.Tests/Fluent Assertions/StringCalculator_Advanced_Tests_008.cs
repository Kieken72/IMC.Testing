using FluentAssertions;
using Xunit;

namespace IMC.Testing.AutoFixtureAndFluentAssertions.Tests
{
    public class StringCalculator_Advanced_Tests_008
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Advanced_Tests_008()
        {
            _calulator = new StringCalulator();   
        }

        [Fact]
        public void Add_With_Multiple_One_Char_Delimiters()
        {
            //Setup

            //Act
            var number = _calulator.Add(@"\\[%][*]\n5%5*5");

            //Assert
            number.Should().Be(15);
        }






    }
}
