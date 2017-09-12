using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IMC.Testing.TDD.Tests
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
            Assert.Equal(75, number);
        }
    }
}
