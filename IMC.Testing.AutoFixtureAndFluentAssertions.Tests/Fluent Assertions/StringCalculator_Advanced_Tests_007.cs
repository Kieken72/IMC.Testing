using FluentAssertions;
using Xunit;

namespace IMC.Testing.AutoFixtureAndFluentAssertions.Tests
{
    public class StringCalculator_Advanced_Tests_007
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Advanced_Tests_007()
        {
            _calulator = new StringCalulator();   
        }

        [Fact]
        public void Add_With_Custom_Delimiter_Longer_Then_One_Char()
        {
            //Setup

            //Act
            var number = _calulator.Add(@"\\***\n5***5***6");

            //Assert
            number.Should().Be(16);
        }

        [Fact]
        public void Add_With_Custom_Delimiter_Longer_Then_One_Char_2()
        {
            //Setup

            //Act
            var number = _calulator.Add(@"\\<><>\n5<><>1000");

            //Assert
            number.Should().Be(1005);
        }






    }
}
