using FluentAssertions;
using Xunit;

namespace IMC.Testing.AutoFixtureAndFluentAssertions.Tests
{
    public class StringCalculator_Advanced_Tests_006
    {
        private readonly StringCalulator _calulator;

        public StringCalculator_Advanced_Tests_006()
        {
            _calulator = new StringCalulator();   
        }

        [Fact]
        public void Add_With_A_Number_Over_Thousand_Doesnt_Get_Added()
        {
            //Setup

            //Act
            var number = _calulator.Add("5,1001");

            //Assert
            number.Should().Be(5);
        }

        [Fact]
        public void Add_With_Thousand_Does_Get_Added()
        {
            //Setup

            //Act
            var number = _calulator.Add("5,1000");

            //Assert
            number.Should().Be(1005);
        }






    }
}
