using System;
using Xunit;

namespace IMC.Testing.TDD.Tests
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
            Assert.Equal(5, number);
        }

        [Fact]
        public void Add_With_Thousand_Does_Get_Added()
        {
            //Setup

            //Act
            var number = _calulator.Add("5,1000");

            //Assert
            Assert.Equal(1005, number);
        }






    }
}
