using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IMC.Testing.TDD.Tests
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
            Assert.Equal(10, number);
        }

        [Fact]
        public void Add_With_Three_Numbers_Returns_Number_Different_Delimiter()
        {
            //Setup

            //Act
            var number = _calulator.Add("\\\\a\\n5a5a5");

            //Assert
            Assert.Equal(15, number);
        }
    }
}
